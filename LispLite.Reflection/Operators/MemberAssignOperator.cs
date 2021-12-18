using LispLite.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LispLite.Operators {
	public class MemberAssignOperator : ILispOperator {

		readonly string MemberName;

		ILispOperator ParentObjectOperator;

		ILispOperator ValueOperator;

		public MemberAssignOperator(string memberName, ILispOperator parentObjectOperator, ILispOperator valueOperator) {
			MemberName = memberName;
			ParentObjectOperator = parentObjectOperator;
			ValueOperator = valueOperator;
		}

		public object Evaluate(IRuntime runtime) {
			var theObject = ParentObjectOperator.Evaluate(runtime);
			var value = ValueOperator.Evaluate(runtime);

			var objectType = theObject.GetType();

			var properties = objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
			var fields = objectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

			var targetProperty = properties.FirstOrDefault(p => p.Name == MemberName);
			var targetField = fields.FirstOrDefault(p => p.Name == MemberName);

			if (targetProperty != null) {
				targetProperty.SetValue(theObject, value);
				return value;
			}
			if (targetField != null) {
				targetField.SetValue(theObject, value);
				return value;
			}
			throw new ArgumentException($"Member {MemberName} not found");

		}
	}
}
