using System;
using System.Collections.Generic;
using System.Linq;
using LispLite.Runtime;

namespace LispLite.Operators {
	public class ArithmeticOperator : ILispOperator {

		public enum ArithmeticsOperation {
			Add,
			Substract,
			Multiphy,
			Divide,
			Mod
		}

		private readonly IReadOnlyList<ILispOperator> Parameters;

		private readonly ArithmeticsOperation Operation;

		public ArithmeticOperator(ArithmeticsOperation operation, params ILispOperator[] code) {
			Parameters = code.ToList();
			Operation = operation;
			if (operation != ArithmeticsOperation.Add && 
				operation != ArithmeticsOperation.Multiphy &&
				Parameters.Count != 2) {
				throw new ArgumentException(nameof(Parameters));
			}
		}

		public object Evaluate(IRuntime runtime) {
			IList<object> result = Parameters.Select(p => p.Evaluate(runtime)).ToList();
			Type t = GetDominantType(result);
			if (t == typeof(string)) {
				if (Operation == ArithmeticsOperation.Add) {
					return string.Concat(result);
				} else {
					throw new InvalidOperationException($"Cannot apply operator {Operation} to string type");
				}
			}
			if (t == typeof(double)) {
				return ProcessDoubles(result, Operation);
			}
			if (t == typeof(int)) {
				return ProcessIntegers(result, Operation);
			}
			return null;
		}

		private Type GetDominantType(IEnumerable<object> values) {
			// select the best type from all types participated in operation
			if (values.Any(v => v.GetType() == typeof(string))) {
				return typeof(string);
			}
			if (values.Any(v => v.GetType() == typeof(double))) {
				return typeof(double);
			}
			if (values.All(v => v.GetType() == typeof(int))) {
				return typeof(int);
			}
			return null;
		}

		private double ProcessDoubles(IEnumerable<object> numbers, ArithmeticsOperation operation) {
			var doubles = numbers.Select(n => double.Parse(n.ToString()));
			double result = doubles.First();
			foreach (var d in doubles.Skip(1)) {
				switch (operation) {
					case ArithmeticsOperation.Add:
						result += d;
						break;
					case ArithmeticsOperation.Substract:
						result -= d;
						break;
					case ArithmeticsOperation.Divide:
						result /= d;
						break;
					case ArithmeticsOperation.Mod:
						result %= d;
						break;
					case ArithmeticsOperation.Multiphy:
						result *= d;
						break;
					default:
						result = 0;
						break;
				}
			}
			return result;
		}

		private int ProcessIntegers(IEnumerable<object> numbers, ArithmeticsOperation operation) {
			var integers = numbers.Select(n => int.Parse(n.ToString()));
			int result = integers.First();
			foreach (var d in integers.Skip(1)) {
				switch (operation) {
					case ArithmeticsOperation.Add:
						result += d;
						break;
					case ArithmeticsOperation.Substract:
						result -= d;
						break;
					case ArithmeticsOperation.Divide:
						result /= d;
						break;
					case ArithmeticsOperation.Mod:
						result %= d;
						break;
					case ArithmeticsOperation.Multiphy:
						result *= d;
						break;
					default:
						result = 0;
						break;
				}
			}
			return result;
		}

	}
}
