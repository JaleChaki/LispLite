using System.Linq;
using LispLite.Syntax;
using Xunit;

namespace LispLite.Tests {
	public class SyntaxReceiverTests {

		[Fact]
		public void BlockTest() {
			var syntaxReceiver = new SyntaxTreeBuilder();
			syntaxReceiver.BeginGroup();
			syntaxReceiver.AddLabel("label1");
			syntaxReceiver.AddLabel("\"string\"");
			syntaxReceiver.BeginGroup();
			syntaxReceiver.AddLabel("label2");
			syntaxReceiver.AddLabel("label3");
			syntaxReceiver.EndGroup();
			syntaxReceiver.EndGroup();
			Validate("(label1 \"string\" (label2 label3))", syntaxReceiver.Build());
		}

		private static void Validate(string expectedBlock, SyntaxNode node) {
			Assert.Equal(expectedBlock, Transform(node));
		}

		private static string Transform(SyntaxNode node) {
			if (node is LabelNode labelNode) {
				return labelNode.ExplicitLabel;
			}
			return "(" + string.Join(" ", (node as SyntaxNodeContainer).Nodes.Select(Transform)) + ")";
		}

	}
}
