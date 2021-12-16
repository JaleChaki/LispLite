using LispLite.Runtime;

namespace LispLite {
	public interface ILispOperator {

		object Evaluate(IRuntime runtime);

	}
}
