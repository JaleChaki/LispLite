using System;
using System.Collections.Generic;
using System.Linq;
using LispLite.Runtime;

namespace LispLite.Operators {
	public class LogicalOperator : ILispOperator {

		public enum LogicalOperatorType {
			And,
			Or,
			Xor,
			Not
		}

		public LogicalOperatorType Type { get; }

		readonly IReadOnlyList<ILispOperator> Operands;

		public LogicalOperator(LogicalOperatorType type, IReadOnlyList<ILispOperator> operands) {
			Type = type;
			Operands = operands;
		}

		public object Evaluate(IRuntime runtime) {
			return Type switch {
				LogicalOperatorType.And => EvaluateAnd(runtime),
				LogicalOperatorType.Or => EvaluateOr(runtime),
				LogicalOperatorType.Xor => EvaluateXor(runtime),
				LogicalOperatorType.Not => EvaluateNot(runtime),
				_ => throw new NotImplementedException()
			};
		}

		bool EvaluateNot(IRuntime runtime) {
			if (Operands.Count > 1) {
				throw new InvalidOperationException("Cannot apply 'not' to many operands");
			}
			return !ConvertToBool(Operands[0].Evaluate(runtime));
		}

		bool EvaluateXor(IRuntime runtime) {
			if (Operands.Count != 2) {
				throw new InvalidOperationException("Cannot apply 'xor'");
			}
			var result1 = ConvertToBool(Operands[0].Evaluate(runtime));
			var result2 = ConvertToBool(Operands[1].Evaluate(runtime));
			return result1 ^ result2;
 		}

		bool EvaluateAnd(IRuntime runtime) {
			foreach (var op in Operands) {
				var result = ConvertToBool(op.Evaluate(runtime));
				if (!result) {
					return false;
				}
			}
			return true;
		}

		bool EvaluateOr(IRuntime runtime) {
			foreach (var op in Operands) {
				var result = ConvertToBool(op.Evaluate(runtime));
				if (result) {
					return true;
				}
			}
			return false;
		}

		static bool ConvertToBool(object value) {
			if (value is not bool booleanValue) {
				throw new ArgumentException("Type is not boolean");
			}
			return booleanValue;
		}
	}
}
