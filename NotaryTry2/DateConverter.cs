using System;
using System.Text.RegularExpressions;

namespace NotaryTry2 {
	class DateConverter {
		private DateTime dt;

		public DateTime DT {
			get => dt;
			set {
				dt = value;
			}
		}
		public DateConverter() {
			DT = new DateTime();
			Console.WriteLine(DT);
		}
		public DateConverter(string dateString) {
			if (DateTime.TryParse(dateString, out DateTime result)) {
				DT = result;
			} else {
				throw new Exception($"\tDate has wrong format!\n\t\"{dateString}\" is unacceptable!");
			}
		}
	}
}
