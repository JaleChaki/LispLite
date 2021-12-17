using System;
using LispLite.Runtime;
using Xunit;

namespace LispLite.Tests.Operators {
	public class AssignOperatorTests {

		[Fact]
		public void Test() {
			var compiler = new LispCompiler();
			var code = compiler.Assemble("(seq (int I 10) (= I 15))");
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(15, runtime.GetVariableValue<int>("I"));
		}

	}
}
