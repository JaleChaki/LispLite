namespace LispLite.Syntax.Compilers {
	public interface ILispSyntaxNodeCompiler {

		bool TryCompile(SyntaxNode node, CompilerService compiler, out ILispOperator result);

	}
}
