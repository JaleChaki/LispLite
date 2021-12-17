using LispLite.Runtime;
using System;
using System.Collections.Generic;

namespace LispLite.Operators {
	public class MakeArrayOperator<T> : ILispOperator {

		readonly IReadOnlyList<ILispOperator> ItemBuilders;

		public MakeArrayOperator(IReadOnlyList<ILispOperator> itemBuilders) {
			ItemBuilders = itemBuilders;
		}

		public object Evaluate(IRuntime runtime) {
			var result = new List<T>();
			foreach (var builder in ItemBuilders) {
				var item = builder.Evaluate(runtime);
				if(item is T typedItem) {
					result.Add(typedItem);
				} else if (item == null && !typeof(T).IsPrimitive) {
					result.Add((T)item);
				} else {
					throw new ArgumentException("Invalid item type");
				}
			}
			return result;
		}
	}
}
