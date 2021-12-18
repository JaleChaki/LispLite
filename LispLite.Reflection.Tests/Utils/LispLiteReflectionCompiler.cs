using LispLite.Syntax.Compilers.Implementation;
using System;
using System.Collections.Generic;

namespace LispLite.Tests.Utils {
	internal class LispLiteReflectionCompiler {

		public static LispCompiler Create() {
			var compiler = new LispCompiler();
			compiler.CompilerService.SyntaxNodeCompilers.Add(new MemberAccessOperatorCompiler());
			compiler.CompilerService.SyntaxNodeCompilers.Add(new MemberAssignOperatorCompiler());
			compiler.CompilerService.SyntaxNodeCompilers.Add(new CreateObjectOperatorCompiler());
			compiler.CompilerService.SupportedTypes.Add("DataItem", typeof(DataItem));
			compiler.CompilerService.SupportedTypes.Add("InternalDataItem", typeof(DataItem.InternalDataItem));
			return compiler;
		}

	}
}
