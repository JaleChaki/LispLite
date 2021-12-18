using System;
using System.Collections.Generic;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class VariableAccessCompiler : ILispSyntaxNodeCompiler {
		public bool TryCompile(SyntaxNode node, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (node is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}
			if (compiler.HasVariable(labelNode.Label)) {
				result = new VariableAccessOperator(labelNode.Label);
				return true;
			}
			return false;
		}
	}
}
