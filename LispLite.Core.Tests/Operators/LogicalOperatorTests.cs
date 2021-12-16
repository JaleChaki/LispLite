using System;
using System.Collections.Generic;
using System.Linq;
using LispLite;
using LispLite.Runtime;
using LispLite.Syntax;
using LispLite.Syntax.Compilers;
using Xunit;

namespace LispLiteTests.Operators {
	public class LogicalOperatorTests {

		[Theory]
		[InlineData("(&& true true)", true)]
		[InlineData("(&& true false)", false)]
		[InlineData("(|| false true)", true)]
		[InlineData("(|| false false)", false)]
		[InlineData("(! false)", true)]
		[InlineData("(! true)", false)]
		[InlineData("(^ true false)", true)]
		[InlineData("(^ true true)", false)]
		[InlineData("(^ false false)", false)]
		public void Test(string code, object expectedResult) {
			var compiler = new LispCompiler();
			var compiledCode = compiler.Assemble(code);
			var actualResult = compiledCode.Evaluate(null);
			Assert.Equal(expectedResult, actualResult);
		}

		[Theory]
		[InlineData("(&& true true false throw)")]
		[InlineData("(|| false false true throw)")]
		public void SequenceBreakTest(string code) {
			var compiler = new LispCompiler();
			compiler.CompilerService.SyntaxNodeCompilers.Add(new ThrowOperatorCompiler());
			var compiledCode = compiler.Assemble(code);
			var exception = Record.Exception(delegate {
				compiledCode.Evaluate(null);
			});
			Assert.Null(exception);
		}

		class ThrowOperatorCompiler : ILispSyntaxNodeCompiler {
			public bool TryCompile(SyntaxNode block, CompilerService compiler, out ILispOperator result) {
				result = null;
				if (block is LabelNode labelNode && labelNode.Label == "throw") {
					result = new ThrowOperator();
					return true;
				}
				return false;
			}
		}

		class ThrowOperator : ILispOperator {
			public object Evaluate(IRuntime runtime) {
				throw new InvalidOperationException("Expected break in operand sequence");
			}
		}

	}
}
