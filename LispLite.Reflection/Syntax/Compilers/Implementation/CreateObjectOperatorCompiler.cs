using LispLite.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LispLite.Syntax.Compilers.Implementation {
	public class CreateObjectOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "new";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (arguments.Count < 1 || arguments[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}
			var type = compiler.GetTypeByDeclaration(labelNode.Label);
			if (type == null) {
				return false;
			}
			result = new CreateObjectOperator(type, arguments.Skip(1).Select(compiler.Compile).ToList());
			return true;
		}

	}
}
