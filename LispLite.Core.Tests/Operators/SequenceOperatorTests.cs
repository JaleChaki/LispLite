using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LispLite;
using LispLite.Runtime;
using Xunit;

namespace LispLiteTests.Operators {
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
