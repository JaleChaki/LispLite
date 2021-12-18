using LispLite.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LispLite.Operators {
	public class MemberAccessOperator : ILispOperator {

		readonly ILispOperator ParentObjectAccessor;

		readonly string MemberName;

		public MemberAccessOperator(ILispOperator parentObjectAccessor, string memberName) {
			ParentObjectAccessor = parentObjectAccessor;
			MemberName = memberName;
		}

		public object Evaluate(IRuntime runtime) {
			var theObject = ParentObjectAccessor.Evaluate(runtime);
			if (theObject == null) {
				return null;
			}
			Type objectType = theObject.GetType();
			var properties = objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
			var fields = objectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

			var targetProperty = properties.FirstOrDefault(p => p.Name == MemberName);
			var targetField = fields.FirstOrDefault(p => p.Name == MemberName);

			if (targetProperty != null) {
				return targetProperty.GetValue(theObject);
			}
			if (targetField != null) {
				return targetField.GetValue(theObject);
			}
			throw new ArgumentException($"Member {MemberName} not found");
		}


	}
}
