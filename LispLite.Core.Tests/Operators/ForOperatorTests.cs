using LispLite.Runtime;
using System;
using System.Collections.Generic;
using Xunit;

namespace LispLite.Tests.Operators {
	public class ForOperatorTests {

		[Fact(Timeout = 1000)]
		public void Test() {
			var code = new LispCompiler().Assemble("(seq (int A 0) (for I 0 10 (= A I)))");
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(9, runtime.GetVariableValue<int>("A"));
			Assert.Throws<ArgumentException>(delegate {
				runtime.GetVariableValue("I");
			});
		}

	}
}
