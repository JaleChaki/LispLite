using LispLite.Operators;
using System.Globalization;

namespace LispLite.Syntax.Compilers.Implementation {
	public class ConstantOperatorCompiler : ILispSyntaxNodeCompiler {
		public bool TryCompile(SyntaxNode node, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (node is not LabelNode labelNode) {
				return false;
			}
			if (labelNode.IsString) {
				result = new ConstantOperator<string>(labelNode.Label);
				return true;
			}
			if (int.TryParse(labelNode.Label, out int intResult)) {
				result = new ConstantOperator<int>(intResult);
				return true;
			}
			if (double.TryParse(labelNode.Label, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleResult)) {
				result = new ConstantOperator<double>(doubleResult);
				return true;
			}
			if (bool.TryParse(labelNode.Label, out bool boolResult)) {
				result = new ConstantOperator<bool>(boolResult);
				return true;
			}
			return false;
		}
	}
}
