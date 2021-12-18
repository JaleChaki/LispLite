using LispLite.Runtime;
using System;
using System.Collections.Generic;

namespace LispLite.Operators {
	public class ForOperator : ILispOperator {

		readonly string IteratorName;

		readonly ILispOperator FromValueOperator;

		readonly ILispOperator ToValueOperator;

		readonly ILispOperator LoopBody;

		public ForOperator(string iteratorName, 
							ILispOperator fromValueOperator, 
							ILispOperator toValueOperator,
							ILispOperator loopBody) {
			IteratorName = iteratorName;
			FromValueOperator = fromValueOperator;
			ToValueOperator = toValueOperator;
			LoopBody = loopBody;
		}

		public object Evaluate(IRuntime runtime) {
			var fromValue = FromValueOperator.Evaluate(runtime);
			if (fromValue is not int fromValueInteger) {
				throw new ArgumentException("'From' should be int");
			}
			var toValue = ToValueOperator.Evaluate(runtime);
			if (toValue is not int toValueInteger) {
				throw new ArgumentException("'To' should be int");
			}

			runtime.DeclareVariable<int>(IteratorName, fromValueInteger);
			int step = Math.Sign(toValueInteger - fromValueInteger);
			for (int i = fromValueInteger; i < toValueInteger; i += step) {
				runtime.SetVariableValue(IteratorName, i);
				LoopBody.Evaluate(runtime);
			}
			runtime.FreeVariable(IteratorName);
			return null;
		}
	}
}
