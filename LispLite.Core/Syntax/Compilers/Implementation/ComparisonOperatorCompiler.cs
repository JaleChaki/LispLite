using System;
using System.Collections.Generic;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class ComparisonOperatorCompiler : LispOperatorCompiler {

		Dictionary<string, ComparisonOperator.ComparisonOperation> ComparisonOperations;

		public ComparisonOperatorCompiler() {
			ComparisonOperations = new Dictionary<string, ComparisonOperator.ComparisonOperation> {
				{ "==", ComparisonOperator.ComparisonOperation.Equal },
				{ "!=", ComparisonOperator.ComparisonOperation.NotEqual },
				{ "<", ComparisonOperator.ComparisonOperation.Less },
				{ "<=", ComparisonOperator.ComparisonOperation.LessOrEqual },
				{ ">", ComparisonOperator.ComparisonOperation.Greater },
				{ ">=", ComparisonOperator.ComparisonOperation.GreaterOrEqual }
			};
		}

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (arguments.Count != 2) {
				return false;
			}
			if (!ComparisonOperations.ContainsKey(operatorName)) {
				return false;
			}
			result = new ComparisonOperator(
				ComparisonOperations[operatorName], 
				compiler.Compile(arguments[0]),
				compiler.Compile(arguments[1])
			);
			return true;
		}
	}
}
