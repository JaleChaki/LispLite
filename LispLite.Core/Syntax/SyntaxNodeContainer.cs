using System.Collections.Generic;

namespace LispLite.Syntax {
	public class SyntaxNodeContainer : SyntaxNode {

		public IReadOnlyList<SyntaxNode> Nodes { get; }

		public SyntaxNodeContainer(IReadOnlyList<SyntaxNode> nodes) {
			Nodes = nodes;
		}
	}
}
