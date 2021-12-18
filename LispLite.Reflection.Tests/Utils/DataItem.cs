using System;
using System.Collections.Generic;
using System.Linq;

namespace LispLite.Tests.Utils {
	internal class DataItem {

		public string Property { get; set; }

		public string Field;

		public InternalDataItem Item { get; set; }

		public class InternalDataItem {

			public int InternalProperty { get; set; }

			public int InternalField;

		}

	}
}
