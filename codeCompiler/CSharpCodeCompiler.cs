using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace codeCompiler {
	/// <summary>
	/// Eine von <see cref="compilerBase"/> abgeleitete Klasse welche das Kompillieren von C# .Net Assemblies ermöglicht.
	/// </summary>
	public class CSharpCodeCompiler : compilerBase {
		/// <summary>
		/// Kompilliert aus den angegebenen Daten ein .Net Assembly.
		/// </summary>
		public override void Compile() {
			var csCodeProvider = new CSharpCodeProvider();
			CompilerParameters cpParameter = buildCompilerParameters();

			CompilerResults cr = csCodeProvider.CompileAssemblyFromSource(cpParameter, codeFiles.ToArray());
			onCompilerFinished(new compilerFinishedEventArgs(cr));
		}
	}
}