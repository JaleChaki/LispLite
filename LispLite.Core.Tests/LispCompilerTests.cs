using Newtonsoft.Json;
using LispLite;
using LispLite.Operators;
using Xunit;

namespace LispLiteTests {
	public class LispCompilerTests {

		[Fact]
		public void TestCompile() {
			var compiler = new LispCompiler();
			var code = compiler.Assemble("(int A 10)") as VariableOperator<int>;
			Assert.NotNull(code);
			Assert.Equal("A", code.Name);
		}

	}
}
