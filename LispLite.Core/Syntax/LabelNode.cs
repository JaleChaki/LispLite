namespace LispLite.Syntax {
	public class LabelNode : SyntaxNode {

		public string Label {
			get {
				if (IsString) {
					return ExplicitLabel.Substring(1, ExplicitLabel.Length - 2);
				} else {
					return ExplicitLabel;
				}
			}
		}

		public string ExplicitLabel { get; }

		public bool IsString => ExplicitLabel.StartsWith("\"") && ExplicitLabel.EndsWith("\"");

		public LabelNode(string label) {
			ExplicitLabel = label;
		}

	}
}
