using LispLite.Runtime;
using System;
using System.Collections;

namespace LispLite.Operators {
	public class ArrayItemSetOperator : ILispOperator {

		readonly string ArrayName;

		readonly ILispOperator IndexGetter;

		readonly ILispOperator ValueOperator;

		public ArrayItemSetOperator(string arrayName, ILispOperator indexGetter, ILispOperator valueOperator) {
			ArrayName = arrayName;
			IndexGetter = indexGetter;
			ValueOperator = valueOperator;
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

			var value = ValueOperator.Evaluate(runtime);
			list[integerIndex] = value;

			return value;
		}

	}
}
