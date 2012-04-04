namespace codeCompiler {
	/// <summary>
	/// Eventhandler für das <see cref="compilerBase.compilerFinished"/>-Event.
	/// </summary>
	/// <param name="sender">Die Instanz welche das Event gefeuert hat.</param>
	/// <param name="e">Gibt das Compilerresultat zurück.</param>
	public delegate void compilerFinishedEventHandler(object sender, compilerFinishedEventArgs e);
}