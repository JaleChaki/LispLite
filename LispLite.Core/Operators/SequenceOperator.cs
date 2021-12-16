using System;
using System.Collections.Generic;
using System.Linq;
using LispLite.Runtime;

namespace LispLite.Operators {
	public class SequenceOperator : ILispOperator {

		readonly IReadOnlyList<ILispOperator> Sequence;

		public SequenceOperator(IReadOnlyList<ILispOperator> sequence) {
			Sequence = sequence;
		}

		public object Evaluate(IRuntime runtime) {
			foreach (ILispOperator code in Sequence) {
				code.Evaluate(runtime);
			}
			return null;
		}
	}
}
