using System;
using System.Collections.Generic;
using LispLite.Operators;

namespace LispLite.Syntax.Compilers.Implementation {
	public class VariableDeclareOperatorCompiler : LispSyntaxNodeContainerCompiler {

		protected override bool TryCompile(SyntaxNodeContainer container, CompilerService compiler, out ILispOperator result) {
			result = null;
			if(container.Nodes.Count < 2) {
				return false;
			}
			if (container.Nodes.Count > 3 ||
				container.Nodes[0] is not LabelNode typeDeclarationLabel ||
				container.Nodes[1] is not LabelNode nameDeclarationLabel ||
				typeDeclarationLabel.IsString ||
				nameDeclarationLabel.IsString) {
				return false;
			}
			var variableType = compiler.GetTypeByDeclaration(typeDeclarationLabel.Label);
			if (variableType == null) {
				return false;
			}
			if(!compiler.CanDeclareVariable(nameDeclarationLabel.Label)) {
				throw new ArgumentException("Variable already exists");
			}
			compiler.DeclareVariable(nameDeclarationLabel.Label);
			result = Activator.CreateInstance(
					typeof(VariableDeclareOperator<>).MakeGenericType(variableType),
					nameDeclarationLabel.Label,
					container.Nodes.Count == 3 ? compiler.Compile(container.Nodes[2]) : null
				) as ILispOperator;
			return true;
		}
	}
}
