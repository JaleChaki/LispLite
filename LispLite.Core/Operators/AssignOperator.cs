using LispLite.Runtime;
using System;

namespace LispLite.Core.Operators {
	public class AssignOperator : ILispOperator {

		readonly string VariableName;

		readonly ILispOperator Value;

		public AssignOperator(string variableName, ILispOperator value) {
			VariableName = variableName;
			Value = value;
		}

		public object Evaluate(IRuntime runtime) {
			var value = Value.Evaluate(runtime);
			runtime.SetVariableValue(VariableName, value);
			return value;
		}
	}
}
