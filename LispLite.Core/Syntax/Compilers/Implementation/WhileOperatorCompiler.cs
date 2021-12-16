using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	internal class WhileOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "while";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if(arguments.Count != 2) {
				return false;
			}
			result = new WhileOperator(
					compiler.Compile(arguments[0]),
					compiler.Compile(arguments[1])
				);
			return true;
		}

	}
}
