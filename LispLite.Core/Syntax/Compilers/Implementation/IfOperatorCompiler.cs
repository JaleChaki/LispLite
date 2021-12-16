using System.Collections.Generic;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class IfOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "if";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = new IfOperator(
					compiler.Compile(arguments[0]),
					compiler.Compile(arguments[1]),
					arguments.Count > 2 ? compiler.Compile(arguments[2]) : null
				);
			return true;
		}
	}
}
