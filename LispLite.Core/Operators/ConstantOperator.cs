using LispLite.Runtime;

namespace LispLite.Operators {
	public class ConstantOperator<T> : ILispOperator {

		public readonly T Value;

		public ConstantOperator(T value) {
			Value = value;
		}

		public object Evaluate(IRuntime runtime) {
			return Value;
		}
	}
}
