using System;

namespace assemblyCompressor.Core {
	[Serializable]
	public class missingArgumentException : Exception {
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		private readonly string _argumentName;

		public missingArgumentException(string argumentName) {
			_argumentName = argumentName;
		}

		public override string Message {
			get { return string.Format("The following, required Parameter is missing: {0}", _argumentName); }
		}
	}
}