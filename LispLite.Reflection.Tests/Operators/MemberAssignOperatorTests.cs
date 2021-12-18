using LispLite.Runtime;
using LispLite.Tests.Utils;
using System;
using Xunit;

namespace LispLite.Tests.Operators {
	public class MemberAssignOperatorTests {

		[Fact]
		public void SimpleAssignProperty() => Test("(= dataItem.Property \"abc\")", x => x.Property, "abc");

		[Fact]
		public void SimpleAssignField() => Test("(= dataItem.Field \"xyz\")", x => x.Field, "xyz");

		[Fact]
		public void ComplexAssignProperty() => Test("(= dataItem.Item.InternalProperty 10)", x => x.Item.InternalProperty, 10);
		
		[Fact]
		public void ComplexAssignField() => Test("(= dataItem.Item.InternalField 20)", x => x.Item.InternalField, 20);

		void Test(string rawCode, Func<DataItem, object> actualValueAccessor, object expectedValue) {
			var compiler = LispLiteReflectionCompiler.Create();
			compiler.CompilerService.DeclareVariable("dataItem");
			var code = compiler.Assemble(rawCode);
			var runtime = new DefaultRuntime();
			runtime.DeclareVariable("dataItem", new DataItem { Item = new DataItem.InternalDataItem() });
			
			Assert.Equal(expectedValue, code.Evaluate(runtime));
			Assert.Equal(expectedValue, actualValueAccessor(runtime.GetVariableValue<DataItem>("dataItem")));
		}
	}
}
