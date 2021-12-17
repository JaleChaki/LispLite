using LispLite.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LispLite.Syntax.Compilers.Implementation {
	public class MakeArrayOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "makearray";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (arguments.Count == 0) {
				return false;
			}
			if (arguments[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}
			var type = compiler.GetTypeByDeclaration(labelNode.Label);
			if (type == null) {
				return false;
			}

			result = Activator.CreateInstance(
				typeof(MakeArrayOperator<>).MakeGenericType(type),
				new List<ILispOperator>(arguments.Skip(1).Select(compiler.Compile))
			) as ILispOperator;
			return true;
		}
	}
}
