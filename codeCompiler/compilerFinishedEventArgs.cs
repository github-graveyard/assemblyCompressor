using System;
using System.CodeDom.Compiler;

namespace codeCompiler {
	/// <summary>
	/// Eventargs für das <see cref="compilerBase.compilerFinished"/>-Event.
	/// </summary>
	public class compilerFinishedEventArgs : EventArgs {
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="compilerFinishedEventArgs"/>.
		/// </summary>
		/// <param name="Results"></param>
		public compilerFinishedEventArgs(CompilerResults Results) {
			CompilerResults = Results;
		}

		/// <summary>
		/// Gibt das Compilerresultat zurück.
		/// </summary>
		public CompilerResults CompilerResults { get; private set; }

		/// <summary>
		/// Gibt 'true' zurück wenn der Kompillierungsvorgang erfolgreich war, andernfalls 'false'.
		/// </summary>
		public bool Success {
			get { return !CompilerResults.Errors.HasErrors; }
		}
	}
}