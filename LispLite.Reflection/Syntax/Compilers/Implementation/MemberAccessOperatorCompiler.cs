using LispLite.Operators;
using System;
using System.Collections.Generic;

namespace LispLite.Syntax.Compilers.Implementation {
	public class MemberAccessOperatorCompiler : ILispSyntaxNodeCompiler {
		public bool TryCompile(SyntaxNode node, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (node is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}

			var memberString = labelNode.Label;
			var memberPath = memberString.Split('.');
			if (!memberString.Contains('.') || !compiler.HasVariable(memberPath[0])) {
				return false;
			}

			ILispOperator current = new VariableAccessOperator(memberPath[0]);
			for (int i = 1; i < memberPath.Length; i++) {
				current = new MemberAccessOperator(current, memberPath[i]);
			}
			result = current;
			return true;
		}
	}
}
