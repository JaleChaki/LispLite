using System;
using System.Collections.Generic;
using System.Linq;
using LispLite.Runtime;

namespace LispLite.Operators {
	public class WhileOperator : ILispOperator {

		readonly ILispOperator Condition;

		readonly ILispOperator Body;

		public WhileOperator(ILispOperator condition, ILispOperator body) {
			Condition = condition;
			Body = body;
		}

		public object Evaluate(IRuntime runtime) {
			while(CheckCondition(runtime)) {
				Body.Evaluate(runtime);
			}
			return null;
		}

		bool CheckCondition(IRuntime runtime) {
			var result = Condition.Evaluate(runtime);
			if (result is not bool booleanResult) {
				throw new ArgumentException("condition is not bool");
			}
			return booleanResult;
		}
	}
}
