using LispLite.Operators;
using Xunit;

namespace LispLite.Tests {
	public class LispCompilerTests {

		[Fact]
		public void TestCompile() {
			var compiler = new LispCompiler();
			var code = compiler.Assemble("(int A 10)") as VariableDeclareOperator<int>;
			Assert.NotNull(code);
			Assert.Equal("A", code.Name);
		}

	}
}
