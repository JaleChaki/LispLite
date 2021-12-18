using LispLite.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LispLite.Tests.Operators {
	public class ArrayItemSetOperatorTests {

		[Fact]
		public void Test() {
			ILispOperator code = new LispCompiler().Assemble("(seq (array<int> A (makearray int 1 2)) (arrayset A 1 -1))");
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);
			Assert.Equal(-1, runtime.GetVariableValue<List<int>>("A")[1]);
		}

	}
}
