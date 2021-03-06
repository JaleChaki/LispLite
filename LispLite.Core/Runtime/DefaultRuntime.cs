using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LispLite.Runtime {
	public class DefaultRuntime : IRuntime {

		public readonly IDictionary<string, object> Variables = new Dictionary<string, object>();

		public void DeclareVariable<T>(string name, T value) {
			Variables.Add(name, value);
		}

		public T GetVariableValue<T>(string name) {
			return (T)GetVariableValue(name);
		}

		public void FreeVariable(string name) {
			EnsureVariableExists(name);
			Variables.Remove(name);
		}

		public object GetVariableValue(string name) {
			EnsureVariableExists(name);
			return Variables[name];
		}

		public void SetVariableValue(string name, object value) {
			EnsureVariableExists(name);
			Variables[name] = value;
		}

		private void EnsureVariableExists(string name) {
			if (!Variables.ContainsKey(name)) {
				throw new ArgumentException($"Variable {name} not exists");
			}
		}
	}
}
