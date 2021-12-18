using LispLite.Operators;
using System;
using System.Collections.Generic;

namespace LispLite.Syntax.Compilers.Implementation {
	public class ForOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "for";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (arguments.Count != 4) {
				return false;
			}
			if (arguments[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}
			compiler.DeclareVariable(labelNode.Label, false);

			result = new ForOperator(
				labelNode.Label,
				compiler.Compile(arguments[1]),
				compiler.Compile(arguments[2]),
				compiler.Compile(arguments[3])
			);
			return true;
		}
	}
}
