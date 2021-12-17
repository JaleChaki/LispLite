using LispLite.Runtime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LispLite.Tests.Operators {
	public class VariableDeclareOperatorTests {

		[Theory]
		[InlineData("(int A 10)", typeof(int), "10")]
		[InlineData("(string A \"abc\")", typeof(string), "\"abc\"")]
		[InlineData("(double A 2.4)", typeof(double), "2.4")]
		[InlineData("(array<double> A (makearray double 1.0))", typeof(List<double>), "[1.0]")]
		[InlineData("(array<array<int>> A (makearray array<int> (makearray int 1)))", typeof(List<List<int>>), "[[1]]")]
		public void Test(string rawCode, Type expectedType, object expectedValueJson) {
			var code = (new LispCompiler()).Assemble(rawCode);
			var runtime = new DefaultRuntime();
			code.Evaluate(runtime);

			var value = runtime.GetVariableValue("A");
			Assert.IsType(expectedType, value);
			Assert.Equal(expectedValueJson, JsonConvert.SerializeObject(value));
		}

	}
}
