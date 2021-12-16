using System;
using System.Collections.Generic;
using LispLite;
using Xunit;

namespace LispLiteTests.Operators {
	public class IfOperatorTests {

		[Theory]
		[InlineData("(if true 1 2)", 1)]
		[InlineData("(if false 1 2)", 2)]
		public void Test(string code, object expectedResult) {
			var compiledCode = (new LispCompiler()).Assemble(code);
			var actualResult = compiledCode.Evaluate(null);
			Assert.Equal(expectedResult, actualResult);
		}

	}
}
