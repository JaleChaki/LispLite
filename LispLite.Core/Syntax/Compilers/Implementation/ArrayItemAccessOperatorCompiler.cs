using LispLite.Operators;
using System;
using System.Collections.Generic;

namespace LispLite.Syntax.Compilers.Implementation {
	public class ArrayItemAccessOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "arrayget";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (arguments.Count != 2) {
				return false;
			}
			if(arguments[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}

			result = new ArrayItemAccessOperator(labelNode.Label, compiler.Compile(arguments[1]));
			return true;
		}
	}
}
