using System;
using LispLite.Runtime;

namespace LispLite.Operators {
	public class ComparisonOperator : ILispOperator {

		public enum ComparisonOperation {
			Equal,
			NotEqual,
			Less,
			LessOrEqual,
			Greater,
			GreaterOrEqual
		}

		public ComparisonOperation Operation { get; }

		readonly ILispOperator LeftOperand;

		readonly ILispOperator RightOperand;

		public ComparisonOperator(ComparisonOperation operation, ILispOperator leftOperand, ILispOperator rightOperand) {
			Operation = operation;
			LeftOperand = leftOperand;
			RightOperand = rightOperand;
		}

		public object Evaluate(IRuntime runtime) {
			var leftOperandValue = LeftOperand.Evaluate(runtime);
			var rightOperandValue = RightOperand.Evaluate(runtime);

			int comparisonResult;
			if (rightOperandValue is double) {
				object comparableObject = leftOperandValue;
				if(leftOperandValue is not double) {
					comparableObject = (double)((int)leftOperandValue);
				}
				comparisonResult = -(rightOperandValue as IComparable).CompareTo(comparableObject);
			} else {
				comparisonResult = (leftOperandValue as IComparable).CompareTo(rightOperandValue);
			}

			return Operation switch {
				ComparisonOperation.Equal => comparisonResult == 0,
				ComparisonOperation.NotEqual => comparisonResult != 0,
				ComparisonOperation.Less => comparisonResult == -1,
				ComparisonOperation.LessOrEqual => comparisonResult < 1,
				ComparisonOperation.Greater => comparisonResult == 1,
				ComparisonOperation.GreaterOrEqual => comparisonResult > -1,
				_ => throw new Exception(),
			};
		}
	}
}
