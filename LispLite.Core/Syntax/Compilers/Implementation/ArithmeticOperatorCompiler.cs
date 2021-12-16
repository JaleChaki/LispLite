using System;
using System.Collections.Generic;
using System.Linq;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class ArithmeticOperatorCompiler : LispOperatorCompiler {

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			ArithmeticOperator.ArithmeticsOperation operation;
			result = null;
			if (operatorName == "+") {
				operation = ArithmeticOperator.ArithmeticsOperation.Add;
			} else if (operatorName == "-") {
				operation = ArithmeticOperator.ArithmeticsOperation.Substract;
			} else if (operatorName == "/") {
				operation = ArithmeticOperator.ArithmeticsOperation.Divide;
			} else if (operatorName == "*") {
				operation = ArithmeticOperator.ArithmeticsOperation.Multiphy;
			} else if (operatorName == "%" && arguments.Count == 2) {
				operation = ArithmeticOperator.ArithmeticsOperation.Mod;
			} else {
				return false;
			}

			result = new ArithmeticOperator(operation, arguments.Select(compiler.Compile).ToArray());
			return true;
		}
	}
}
