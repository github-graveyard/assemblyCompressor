using System;
using System.Collections;
using System.Collections.Generic;

namespace assemblyCompressor.Core {
	[Serializable]
	public class assemblyCollection : ICollection<assemblyInformation> {
		private readonly List<assemblyInformation> _storage = new List<assemblyInformation>();

		#region ICollection<assemblyInformation> Members

		public void Add(assemblyInformation item) {
			_storage.Add(item);
		}

		public void Clear() {
			_storage.Clear();
		}

		public bool Contains(assemblyInformation item) {
			return _storage.Contains(item);
		}

		public void CopyTo(assemblyInformation[] array, int arrayIndex) {
			_storage.CopyTo(array, arrayIndex);
		}

		public int Count {
			get { return _storage.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public bool Remove(assemblyInformation item) {
			return _storage.Remove(item);
		}

		public IEnumerator<assemblyInformation> GetEnumerator() {
			return _storage.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _storage.GetEnumerator();
		}

		#endregion

		public void AddRange(IEnumerable<assemblyInformation> items) {
			_storage.AddRange(items);
		}

		public bool Contains(string Id) {
			foreach (assemblyInformation item in _storage) {
				if (item.Id.Equals(Id)) {
					return true;
				}
			}
			return false;
		}

		public bool ContainsPath(string path) {
			foreach (assemblyInformation item in _storage) {
				if (item.Path.Equals(path)) {
					return true;
				}
			}
			return false;
		}

		public bool Remove(string Id) {
			for (int i = 0; i < _storage.Count; i++) {
				if (_storage[i].Id.Equals(Id)) {
					_storage.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
	}
}