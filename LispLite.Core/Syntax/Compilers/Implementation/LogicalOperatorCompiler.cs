using System;
using System.Collections.Generic;
using System.Linq;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class LogicalOperatorCompiler : LispOperatorCompiler {

		readonly IDictionary<string, LogicalOperator.LogicalOperatorType> LogicalOperations;

		public LogicalOperatorCompiler() {
			LogicalOperations = new Dictionary<string, LogicalOperator.LogicalOperatorType>();
			LogicalOperations.Add("&&", LogicalOperator.LogicalOperatorType.And);
			LogicalOperations.Add("||", LogicalOperator.LogicalOperatorType.Or);
			LogicalOperations.Add("^", LogicalOperator.LogicalOperatorType.Xor);
			LogicalOperations.Add("!", LogicalOperator.LogicalOperatorType.Not);
		}

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (!LogicalOperations.ContainsKey(operatorName)) {
				return false;
			}
			result = new LogicalOperator(LogicalOperations[operatorName], arguments.Select(compiler.Compile).ToArray());
			return true;
		}
	}
}
