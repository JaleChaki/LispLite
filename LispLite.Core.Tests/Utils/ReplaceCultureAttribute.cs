using System;
using System.Globalization;
using System.Reflection;
using Xunit.Sdk;

namespace LispLiteTests.Utils {
	internal class ReplaceCultureAttribute : BeforeAfterTestAttribute {

		public string CultureName { get; set; } = "en-us";

		private CultureInfo PrevCulture { get; set; }

		public override void Before(MethodInfo methodUnderTest) {
			base.Before(methodUnderTest);
			PrevCulture = CultureInfo.CurrentCulture;
			CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(CultureName);
		}

		public override void After(MethodInfo methodUnderTest) {
			CultureInfo.CurrentCulture = PrevCulture;
		}

	}
}
