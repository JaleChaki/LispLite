using LispLite.Runtime;

namespace LispLite.Operators {
	public class IfOperator : ILispOperator {

		private readonly ILispOperator Condition;

		private readonly ILispOperator OnTrue;

		private readonly ILispOperator OnFalse;

		public IfOperator(ILispOperator condition, ILispOperator onTrue, ILispOperator onFalse = null) {
			Condition = condition;
			OnTrue = onTrue;
			OnFalse = onFalse;
		}

		public object Evaluate(IRuntime runtime) {
			bool conditionResult = (bool)Condition.Evaluate(runtime);
			if (conditionResult) {
				return OnTrue.Evaluate(runtime);
			} else {
				return OnFalse?.Evaluate(runtime);
			}
		}
	}
}
