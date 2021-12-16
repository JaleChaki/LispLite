using LispLite.Runtime;

namespace LispLite.Operators {
	public class VariableOperator<T> : ILispOperator {

		public string Name { get; }

		private readonly ILispOperator PrimaryValueSetter;

		public VariableOperator(string name, ILispOperator primaryValueSetter) {
			Name = name;
			PrimaryValueSetter = primaryValueSetter;
		}

		public object Evaluate(IRuntime runtime) {
			T value = (T)PrimaryValueSetter.Evaluate(runtime);
			runtime.DeclareVariable<T>(Name, value);
			return value;
		}
	}
}
