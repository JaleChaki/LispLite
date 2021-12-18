using LispLite.Syntax.Compilers.Implementation;
using System;
using System.Collections.Generic;

namespace LispLite.Tests.Utils {
	internal class LispLiteReflectionCompiler {

		public static LispCompiler CreateNew() {
			var compiler = new LispCompiler();
			compiler.CompilerService.SyntaxNodeCompilers.Add(new MemberAccessOperatorCompiler());
			compiler.CompilerService.SupportedTypes.Add("DataItem", typeof(DataItem));
			return compiler;
		}

	}
}
