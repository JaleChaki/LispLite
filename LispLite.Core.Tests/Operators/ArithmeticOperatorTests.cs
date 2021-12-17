using Xunit;

namespace LispLite.Tests.Operators {
	public class ArithmeticOperatorTests {

		[Theory]
		[InlineData("(+ 1 2 3)", 6)]
		[InlineData("(- 2 2)", 0)]
		[InlineData("(* 2 2)", 4)]
		[InlineData("(/ 6 2)", 3)]
		[InlineData("(% 9 2)", 1)]
		[InlineData("(+ 1 2 \"something\")", "12something")]
		[InlineData("(+ 1.0 2 3)", 6.0)]
		[InlineData("(- 2.0 2)", 0.0)]
		[InlineData("(* 2.0 2)", 4.0)]
		[InlineData("(/ 7.0 2)", 3.5)]
		public void Test(string code, object expectedResult) {
			var compiler = new LispCompiler();
			var compiledCode = compiler.Assemble(code);
			var actualResult = compiledCode.Evaluate(null);
			Assert.Equal(expectedResult, actualResult);
		}

	}
}
