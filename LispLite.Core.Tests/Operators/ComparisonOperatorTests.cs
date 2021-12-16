using System;
using LispLite;
using Xunit;

namespace LispLiteTests.Operators {
	public class ComparisonOperatorTests {

		[Theory]
		[InlineData("(== 1 1)", true)]
		[InlineData("(== 2 1)", false)]
		[InlineData("(!= 2 1)", true)]
		[InlineData("(!= 2 2)", false)]
		[InlineData("(< 1 2)", true)]
		[InlineData("(< 2 1)", false)]
		[InlineData("(<= 2 2)", true)]
		[InlineData("(<= 2 1)", false)]
		[InlineData("(> 2 1)", true)]
		[InlineData("(> 1 2)", false)]
		[InlineData("(>= 2 2)", true)]
		[InlineData("(>= 1 2)", false)]
		public void Integers(string code, bool expectedResult) {
			Assert.Equal(expectedResult, (new LispCompiler()).Assemble(code).Evaluate(null));
		}

		[Theory]
		[InlineData("(== 1.0 1.0)", true)]
		[InlineData("(== 2.0 1.0)", false)]
		[InlineData("(!= 2.0 1.0)", true)]
		[InlineData("(!= 2.0 2.0)", false)]
		[InlineData("(< 1.0 2.0)", true)]
		[InlineData("(< 2.0 1.0)", false)]
		[InlineData("(<= 2.0 2.0)", true)]
		[InlineData("(<= 2.0 1.0)", false)]
		[InlineData("(> 2.0 1.0)", true)]
		[InlineData("(> 1.0 2.0)", false)]
		[InlineData("(>= 2.0 2.0)", true)]
		[InlineData("(>= 1.0 2.0)", false)]
		public void Doubles(string code, bool expectedResult) {
			Assert.Equal(expectedResult, (new LispCompiler()).Assemble(code).Evaluate(null));
		}

		[Theory]
		[InlineData("(== \"A\" \"A\")", true)]
		[InlineData("(== \"B\" \"A\")", false)]
		[InlineData("(!= \"B\" \"A\")", true)]
		[InlineData("(!= \"B\" \"B\")", false)]
		[InlineData("(< \"A\" \"B\")", true)]
		[InlineData("(< \"B\" \"A\")", false)]
		[InlineData("(<= \"B\" \"B\")", true)]
		[InlineData("(<= \"B\" \"A\")", false)]
		[InlineData("(> \"B\" \"A\")", true)]
		[InlineData("(> \"A\" \"B\")", false)]
		[InlineData("(>= \"B\" \"B\")", true)]
		[InlineData("(>= \"A\" \"B\")", false)]
		public void Strings(string code, bool expectedResult) {
			Assert.Equal(expectedResult, (new LispCompiler()).Assemble(code).Evaluate(null));
		}

		[Theory]
		[InlineData("(== 1 1.0)", true)]
		[InlineData("(== 2 1.0)", false)]
		[InlineData("(!= 2 1.0)", true)]
		[InlineData("(!= 2 2.0)", false)]
		[InlineData("(< 1 2.0)", true)]
		[InlineData("(< 2 1.0)", false)]
		[InlineData("(<= 2 2.0)", true)]
		[InlineData("(<= 2 1.0)", false)]
		[InlineData("(> 2 1.0)", true)]
		[InlineData("(> 1 2.0)", false)]
		[InlineData("(>= 2 2.0)", true)]
		[InlineData("(>= 1 2.0)", false)]
		public void MixedTypes(string code, bool expectedResult) {
			Assert.Equal(expectedResult, (new LispCompiler()).Assemble(code).Evaluate(null));
		}

	}
}
