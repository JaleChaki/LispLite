using LispLite.Runtime;

namespace LispLite.Operators {
	public class VariableDeclareOperator<T> : ILispOperator {

		public string Name { get; }

		private readonly ILispOperator PrimaryValueSetter;

		public VariableDeclareOperator(string name, ILispOperator primaryValueSetter) {
			Name = name;
			PrimaryValueSetter = primaryValueSetter;
		}

		public object Evaluate(IRuntime runtime) {
			var value = PrimaryValueSetter?.Evaluate(runtime);
			runtime.DeclareVariable(Name, value ?? default(T));
			return value;
		}
	}
}
