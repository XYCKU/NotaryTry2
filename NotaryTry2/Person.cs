using System;

namespace NotaryTry2 {
	class Person {
		private readonly string[] FAMILY_NAMES = { "Богданович", "Андреенко", "Иванов", "Рубаха", "Карманов" };
		private readonly string[] FIRST_NAMES = { "Андрей", "Максим", "Виктор", "Александр", "Николай" };
		private readonly string[] SECOND_NAMES = { "Сергеевич", "Витальевич", "Александрович", "Михайлович", "Андреевич" };

		private static readonly Random rand = new Random();

		private Name FullName { get; set; } = null;
		private PassportData Passport { get; set; } = null;
		public Person() {
			FullName = new Name(GetRandomFromArray(FAMILY_NAMES),
								GetRandomFromArray(FIRST_NAMES),
								GetRandomFromArray(SECOND_NAMES));
			Passport = new PassportData();
		}

		public Person(string famName, string firName, string secName) {
			try {
				FullName = new Name(famName, firName, secName);
			} catch(Exception e) {
				Console.WriteLine($"=====================================\nPerson wasn't created:\n{e.Message}\n=====================================\n");
				
			}
		}

		public string GetFullName() {
			return this.FullName.ToString();
		}
		public string GetPassportData() {
			return this.Passport.ToString();
		}

		override public string ToString() {
			return $"{this.GetFullName()}\n{this.GetPassportData()}\n";
		}

		private string GetRandomFromArray(string[] arr) {

			return arr[rand.Next(arr.Length)];
		}
	}
}