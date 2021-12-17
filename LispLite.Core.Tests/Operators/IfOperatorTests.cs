using System;
using System.Collections.Generic;
using Xunit;

namespace LispLite.Tests.Operators {
	public class IfOperatorTests {

		[Theory]
		[InlineData("(if true 1 2)", 1)]
		[InlineData("(if false 1 2)", 2)]
		[InlineData("(if true 1)", 1)]
		[InlineData("(if false 1)", null)]
		public void Test(string code, object expectedResult) {
			var compiledCode = (new LispCompiler()).Assemble(code);
			var actualResult = compiledCode.Evaluate(null);
			Assert.Equal(expectedResult, actualResult);
		}

	}
}
