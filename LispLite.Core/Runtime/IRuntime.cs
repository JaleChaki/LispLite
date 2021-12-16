namespace LispLite.Runtime {

	/// <summary>
	/// execution environment
	/// </summary>
	public interface IRuntime {

		void DeclareVariable<T>(string name, T value);

		void SetVariableValue(string name, object value);

		T GetVariableValue<T>(string name);

		object GetVariableValue(string name);

	}
}
