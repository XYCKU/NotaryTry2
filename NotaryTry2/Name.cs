using System;
using System.Text.RegularExpressions;

namespace NotaryTry2 {
	class Name {
		private static readonly Regex REGEX = new Regex(@"^[А-Я][а-я]{0,30}$");

		private string familyName, firstName, secondName;

		public string FamilyName {
			get => familyName;
			set { 
				if (REGEX.IsMatch(value)) {
					familyName = value;
				} else {
					throw new Exception($"\tFamily Name has wrong format!\n\t\"{value}\" is unacceptable!");
				}
			} 
		}
		public string FirstName {
			get => firstName;
			set {
				if (REGEX.IsMatch(value)) {
					firstName = value;
				} else {
					throw new Exception($"\tFirst Name has wrong format!\n\t\"{value}\" is unacceptable!");
				}
			}
		}
		public string SecondName {
			get => secondName;
			set {
				if (REGEX.IsMatch(value)) {
					secondName = value;
				} else {
					throw new Exception($"\tSecond Name has wrong format!\n\t\"{value}\" is unacceptable!");
				}
			}
		}
		
		
		public Name(string famName, string firName, string secName) {
			FamilyName = famName;
			FirstName = firName;
			SecondName = secName;
		}		

		override public string ToString() {
			return $"{this.FamilyName} {this.FirstName} {this.SecondName}";
		}
	}
}
