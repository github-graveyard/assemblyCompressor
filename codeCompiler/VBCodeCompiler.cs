using System.CodeDom.Compiler;
using Microsoft.VisualBasic;

namespace codeCompiler {
	/// <summary>
	/// Eine von <see cref="compilerBase"/> abgeleitete Klasse welche das Kompillieren von VB.Net Assemblies ermöglicht.
	/// </summary>
	public class VBCodeCompiler : compilerBase {
		/// <summary>
		/// Kompilliert aus den angegebenen Daten ein .Net Assembly
		/// </summary>
		public override void Compile() {
			var vbcodeprovider = new VBCodeProvider();
			CompilerParameters cpParameter = buildCompilerParameters();

			CompilerResults cr = vbcodeprovider.CompileAssemblyFromSource(cpParameter, codeFiles.ToArray());
			onCompilerFinished(new compilerFinishedEventArgs(cr));
		}
	}
}