using LispLite.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LispLite.Operators {
	public class CreateObjectOperator : ILispOperator {

		public readonly Type ObjectType;

		public readonly IReadOnlyList<ILispOperator> ArgumentOperators;

		public CreateObjectOperator(Type objectType, IReadOnlyList<ILispOperator> argumentOperators) {
			ObjectType = objectType;
			ArgumentOperators = argumentOperators;
		}

		public object Evaluate(IRuntime runtime) {
			return Activator.CreateInstance(ObjectType, ArgumentOperators.Select(x => x.Evaluate(runtime)).ToArray());
		}
	}
}
