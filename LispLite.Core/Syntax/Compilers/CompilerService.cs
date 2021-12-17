using System;
using System.Collections.Generic;
using LispLite.Syntax.Compilers.Implementation;

namespace LispLite.Syntax.Compilers {
	public class CompilerService {

		private readonly IDictionary<string, Type> SupportedTypes;

		public ICollection<ILispSyntaxNodeCompiler> SyntaxNodeCompilers { get; }

		/// <summary>
		/// names of variables, declared during compilation
		/// </summary>
		public ICollection<string> DeclaredVariables { get; }

		public CompilerService(IDictionary<string, Type> supportedTypes) {
			SupportedTypes = supportedTypes;
			SupportedTypes.Add("int", typeof(int));
			SupportedTypes.Add("double", typeof(double));
			SupportedTypes.Add("string", typeof(string));
			SupportedTypes.Add("bool", typeof(bool));

			SyntaxNodeCompilers = new List<ILispSyntaxNodeCompiler> {
				new VariableDeclareOperatorCompiler(),
				new ConstantOperatorCompiler(),
				new ArithmeticOperatorCompiler(),
				new LogicalOperatorCompiler(),
				new IfOperatorCompiler(),
				new ComparisonOperatorCompiler(),
				new VariableAccessCompiler(),
				new WhileOperatorCompiler(),
				new SequenceOperatorCompiler(),
				new AssignOperatorCompiler(),
				new MakeArrayOperatorCompiler()
			};

			DeclaredVariables = new List<string>();
		}

		public Type GetTypeByDeclaration(string name) {
			if (name.StartsWith("array<") && name.EndsWith(">")) {
				var arrayType = name.Substring("array<".Length, name.Length - "array<".Length - 1);

				return typeof(List<>).MakeGenericType(GetTypeByDeclaration(arrayType));
			}

			return SupportedTypes.TryGetValue(name, out Type result) ? result : null;
		}

		public ILispOperator Compile(SyntaxNode node) {
			foreach (var compiler in SyntaxNodeCompilers) {
				if (compiler.TryCompile(node, this, out ILispOperator code)) {
					return code;
				}
			}
			throw new Exception();
		}

	}
}
