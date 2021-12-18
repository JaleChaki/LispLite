using LispLite.Tests.Utils;
using System;
using System.Collections.Generic;
using Xunit;

namespace LispLite.Tests.Operators {
	public class CreateObjectOperatorTests {

		[Fact]
		public void CreateEmptyConstructor() {
			var compiler = LispLiteReflectionCompiler.Create();
			var code = compiler.Assemble("(new DataItem)");
			var dataItem = code.Evaluate(null);
			Assert.NotNull(dataItem);
			Assert.IsType<DataItem>(dataItem);
		}

		[Fact]
		public void CreateComplexConstructor() {
			var compiler = LispLiteReflectionCompiler.Create();
			var code = compiler.Assemble("(new DataItem \"abc\" \"xyz\" (new InternalDataItem 10 20))");
			var dataItem = (DataItem)code.Evaluate(null);
			Assert.Equal("abc", dataItem.Property);
			Assert.Equal("xyz", dataItem.Field);
			Assert.Equal(10, dataItem.Item.InternalProperty);
			Assert.Equal(20, dataItem.Item.InternalField);
		}

	}
}
