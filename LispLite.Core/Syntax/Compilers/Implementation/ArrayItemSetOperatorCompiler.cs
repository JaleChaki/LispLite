using LispLite.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LispLite.Syntax.Compilers.Implementation {
	public class ArrayItemSetOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "arrayset";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (arguments.Count != 3) {
				return false;
			}
			if (arguments[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}

			result = new ArrayItemSetOperator(labelNode.Label, compiler.Compile(arguments[1]), compiler.Compile(arguments[2]));
			return true;
		}
	}
}
