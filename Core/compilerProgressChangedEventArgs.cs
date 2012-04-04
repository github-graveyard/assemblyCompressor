using System;

namespace assemblyCompressor.Core {
	internal class compilerProgressChangedEventArgs : EventArgs {
		public compilerProgressChangedEventArgs(int percentdone) {
			PercentDone = percentdone;
		}

		public int PercentDone { get; set; }
	}
}