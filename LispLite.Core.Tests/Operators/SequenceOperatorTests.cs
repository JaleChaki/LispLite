using System;
using LispLite.Runtime;
using Xunit;

namespace LispLite.Tests.Operators {
	public class SequenceOperatorTests {

		[Fact]
		public void Test() {
			LispCompiler compiler = new LispCompiler();
			var code = compiler.Assemble("(seq (int A 10) (string X \"abc\"))");
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(10, runtime.GetVariableValue("A"));
			Assert.Equal("abc", runtime.GetVariableValue("X"));
		}

	}
}
