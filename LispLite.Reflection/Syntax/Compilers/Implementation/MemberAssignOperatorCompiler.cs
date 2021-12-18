using LispLite.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLite.Syntax.Compilers.Implementation {
	public class MemberAssignOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "=";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = null;
			if(arguments.Count != 2) {
				return false;
			}
			if (arguments[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}

			var memberString = labelNode.Label;
			var memberPath = memberString.Split('.');
			if (!memberString.Contains('.') || !compiler.HasVariable(memberPath[0])) {
				return false;
			}

			ILispOperator current = new VariableAccessOperator(memberPath[0]);
			for (int i = 1; i < memberPath.Length - 1; i++) {
				current = new MemberAccessOperator(current, memberPath[i]);
			}
			result = new MemberAssignOperator(memberPath.Last(), current, compiler.Compile(arguments[1]));
			return true;
		}
	}
}
