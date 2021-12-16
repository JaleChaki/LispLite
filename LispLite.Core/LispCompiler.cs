using System;
using System.Collections.Generic;
using System.Text;
using LispLite.Syntax.Compilers;

namespace LispLite {
	public class LispCompiler {

		public CompilerService CompilerService { get; set; }

		public LispCompiler() {
			CompilerService = new CompilerService(new Dictionary<string, Type>());
		}

		public virtual ILispOperator Assemble(string code) {
			SyntaxTreeBuilder syntaxTreeBuilder = new SyntaxTreeBuilder();
			for (int i = 0; i < code.Length; ++i) {
				if (code[i] == '(') {
					syntaxTreeBuilder.BeginGroup();
					continue;
				}
				if (code[i] == ')') {
					syntaxTreeBuilder.EndGroup();
					continue;
				}
				if (code[i] != ' ') {
					syntaxTreeBuilder.AddLabel(CompileLabel(code, ref i));
				}
			}
			return CompilerService.Compile(syntaxTreeBuilder.Build());
		}

		protected virtual string CompileLabel(string code, ref int index) {
			bool startsWithQuote = code[index] == '\"';
			var result = new StringBuilder(code[index] + "");
			while (index < code.Length - 1) {
				++index;
				if ((code[index] == ' ' || code[index] == ')') && !startsWithQuote) {
					--index;
					return result.ToString();
				}
				result.Append(code[index]);
				if (code[index] == '\"' && startsWithQuote) {
					return result.ToString();
				}
			}
			return result.ToString();
		}

	}
}
