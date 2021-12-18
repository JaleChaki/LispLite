using System;
using System.Collections.Generic;
using System.Linq;

namespace LispLite.Tests.Utils {
	internal class DataItem {

		public string Property { get; set; }

		public string Field;

		public InternalDataItem Item { get; set; }

		public class InternalDataItem {

			public InternalDataItem() {

			}

			public InternalDataItem(int a, int b) {
				InternalProperty = a;
				InternalField = b;
			}

			public int InternalProperty { get; set; }

			public int InternalField;

		}

		public DataItem() {

		}

		public DataItem(string property, string field, InternalDataItem item) {
			Property = property;
			Field = field;
			Item = item;
		}

	}
}
