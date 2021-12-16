using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class SequenceOperatorCompiler : LispOperatorCompiler {

		protected override string OperatorName => "seq";

		protected override bool TryCompile(string operatorName, IReadOnlyList<SyntaxNode> arguments, CompilerService compiler, out ILispOperator result) {
			result = new SequenceOperator(arguments.Select(compiler.Compile).ToArray());
			return true;
		}
	}
}
