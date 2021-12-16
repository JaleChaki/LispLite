using System;
using System.Collections.Generic;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class VariableDeclarationCompiler : LispSyntaxNodeContainerCompiler {

		protected override bool TryCompile(SyntaxNodeContainer container, CompilerService compiler, out ILispOperator result) {
			result = null;
			var typeDeclarationLabel = container.Nodes[0] as LabelNode;
			var nameDeclarationLabel = container.Nodes[1] as LabelNode;
			if (container.Nodes.Count != 3 ||
				typeDeclarationLabel == null ||
				nameDeclarationLabel == null ||
				typeDeclarationLabel.IsString ||
				nameDeclarationLabel.IsString) {
				return false;
			}
			var variableType = compiler.GetTypeByDeclaration(typeDeclarationLabel.Label);
			if (variableType == null) {
				return false;
			}
			if(compiler.DeclaredVariables.Contains(nameDeclarationLabel.Label)) {
				throw new ArgumentException("Variable already exists");
			}
			compiler.DeclaredVariables.Add(nameDeclarationLabel.Label);
			result = Activator.CreateInstance(
					typeof(VariableOperator<>).MakeGenericType(variableType),
					nameDeclarationLabel.Label,
					compiler.Compile(container.Nodes[2])
				) as ILispOperator;
			return true;
		}
	}
}
