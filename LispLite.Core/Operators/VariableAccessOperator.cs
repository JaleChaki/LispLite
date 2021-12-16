using LispLite.Runtime;

namespace LispLite.Operators {
	public class VariableAccessOperator : ILispOperator {
		
		readonly string Name;

		public VariableAccessOperator(string name) {
			Name = name;
		}

		public object Evaluate(IRuntime runtime) {
			return runtime.GetVariableValue(Name);
		}
	}
}
