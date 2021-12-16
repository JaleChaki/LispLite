namespace LispLite.Syntax.Compilers {
	public abstract class LispSyntaxNodeContainerCompiler : ILispSyntaxNodeCompiler {

		protected abstract bool TryCompile(SyntaxNodeContainer group, CompilerService compiler, out ILispOperator result);

		public bool TryCompile(SyntaxNode node, CompilerService compiler, out ILispOperator result) {
			result = null;
			if (node is not SyntaxNodeContainer container) {
				return false;
			}
			return TryCompile(container, compiler, out result);
		}
	}
}
