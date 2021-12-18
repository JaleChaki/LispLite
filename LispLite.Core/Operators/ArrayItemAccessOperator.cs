using LispLite.Runtime;
using System;
using System.Collections;

namespace LispLite.Operators {
	public class ArrayItemAccessOperator : ILispOperator {

		readonly string ArrayName;

		readonly ILispOperator IndexGetter;

		public ArrayItemAccessOperator(string arrayName, ILispOperator indexGetter) {
			ArrayName = arrayName;
			IndexGetter = indexGetter;
		}

		public object Evaluate(IRuntime runtime) {
			var variable = runtime.GetVariableValue(ArrayName);
			if (variable is not IList list) {
				throw new ArgumentException($"{ArrayName} is not array");
			}

			var index = IndexGetter.Evaluate(runtime);
			if (index is not int integerIndex) {
				throw new ArgumentException("index type is not int");
			}

			return list[integerIndex];
		}
	}
}
