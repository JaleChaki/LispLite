using LispLite.Runtime;
using System;
using Xunit;

namespace LispLite.Tests.Operators {
	public class WhileOperatorTests {

		[Fact(Timeout = 1000)]
		public void Test() {
			var code = new LispCompiler().Assemble("(seq (int I 1) (while (< I 10) (= I (+ I 1))))");
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(10, runtime.GetVariableValue<int>("I"));
		}

	}
}
