using LispLite.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LispLite.Tests.Operators {
	public class ArrayItemAccessOperatorTests {

		[Fact]
		public void Test() {
			ILispOperator code = new LispCompiler().Assemble("(seq (array<int> A (makearray int 1 2)) (int val (arrayget A 1)))");
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(2, runtime.GetVariableValue<int>("val"));	
		}

	}
}
