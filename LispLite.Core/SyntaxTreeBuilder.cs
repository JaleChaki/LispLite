using System;
using System.Collections.Generic;
using LispLite.Syntax;

namespace LispLite {
	public class SyntaxTreeBuilder {

		private readonly Stack<List<SyntaxNode>> SyntaxNodes = new Stack<List<SyntaxNode>>();

		private void EnsureDepth() {
			if (SyntaxNodes.Count == 0) {
				throw new InvalidOperationException();
			}
		}

		public void BeginGroup() {
			SyntaxNodes.Push(new List<SyntaxNode>());
		}

		public void EndGroup() {
			EnsureDepth();
			if (SyntaxNodes.Count > 1) {
				var container = new SyntaxNodeContainer(SyntaxNodes.Pop());
				SyntaxNodes.Peek().Add(container);
			}
		}

		public void AddLabel(string label) {
			SyntaxNodes.Peek().Add(new LabelNode(label));
		}

		public SyntaxNode Build() {
			var result = new SyntaxNodeContainer(SyntaxNodes.Peek());
			if (SyntaxNodes.Count > 1) {
				throw new InvalidOperationException("Unable to build syntax tree while depth > 0");
			} else {
				SyntaxNodes.Pop();
			}
			return result;
		}
	}
}
