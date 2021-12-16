using System.Collections.Generic;
using System.Linq;

namespace LispLite.Syntax.Compilers {
	public abstract class LispOperatorCompiler : LispSyntaxNodeContainerCompiler {

		protected virtual string OperatorName => null;

		protected sealed override bool TryCompile(SyntaxNodeContainer container, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (container.Nodes.Count == 0 || container.Nodes[0] is not LabelNode labelNode || labelNode.IsString) {
				return false;
			}
			var operatorName = labelNode.Label;
			if (OperatorName == operatorName || OperatorName == null) {
				return TryCompile(operatorName, container.Nodes.Skip(1).ToArray(), compiler, out result);
			}
			return false;
		}

		protected abstract bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result);
		
	}
}
