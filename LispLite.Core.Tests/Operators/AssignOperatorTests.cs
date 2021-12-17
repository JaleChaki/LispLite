using System;
using LispLite.Runtime;
using Xunit;

namespace LispLite.Tests.Operators {
	public class AssignOperatorTests {

		[Theory]
		[InlineData("(seq (int A 10) (= A 15))", 15)]
		[InlineData("(seq (string A \"abc\") (= A \"xyz\"))", "xyz")]
		[InlineData("(seq (double A 1.0) (= A 1.5))", 1.5)]
		[InlineData("(seq (bool A false) (= A true))", true)]
		public void Test(string rawCode, object expectedValue) {
			var compiler = new LispCompiler();
			var code = compiler.Assemble(rawCode);
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(expectedValue, runtime.GetVariableValue("A"));
		}

	}
}
