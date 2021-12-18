using LispLite.Runtime;
using LispLite.Tests.Utils;
using Xunit;

namespace LispLite.Tests {
	public class MemberAccessOperatorTests {

		[Fact]
		public void SimpleAccessProperty() => Test("(string A dataItem.Property)", "abc");

		[Fact]
		public void SimpleAccessField() => Test("(string A dataItem.Field)", "xyz");

		[Fact]
		public void ComplexAccessProperty() => Test("(int A dataItem.Item.InternalProperty)", 123);

		[Fact]
		public void ComplexAccessField() => Test("(int A dataItem.Item.InternalField)", 456);

		void Test(string rawCode, object expectedValue) {
			var compiler = LispLiteReflectionCompiler.CreateNew();
			compiler.CompilerService.DeclareVariable("dataItem");
			var code = compiler.Assemble(rawCode);
			var runtime = new DefaultRuntime();
			runtime.DeclareVariable<DataItem>("dataItem", CreateDataItem());
			code.Evaluate(runtime);
			Assert.Equal(expectedValue, runtime.GetVariableValue("A"));
		}

		DataItem CreateDataItem() {
			return new DataItem {
				Property = "abc",
				Field = "xyz",
				Item = new DataItem.InternalDataItem {
					InternalProperty = 123,
					InternalField = 456
				}
			};
		}

	}
}