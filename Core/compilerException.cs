using System;

namespace assemblyCompressor.Core {
	internal class compilerException : Exception {
		public compilerException(string Message)
			: base(Message) {
		}
	}
}