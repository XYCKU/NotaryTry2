using System;
using System.Text.RegularExpressions;

namespace NotaryTry2 {
	class PassportData {
		private static Random rand = new Random();

		private static readonly Regex PASS_SERIAL_REGEX = new Regex(@"^([A-Z]|[А-Я]){2}\d{7}$");
		private static readonly Regex PASS_PERSONAL_REGEX = new Regex(@"^\d{7}([A-Z]|[А-Я])\d{3}([A-Z]|[А-Я]){2}\d$");
		
		private string passportSerial, passportPersonal;
		private DateTime passportDate;
		
		public string PassportSerial {
			get => passportSerial;
			set {
				if (PASS_SERIAL_REGEX.IsMatch(value)) {
					passportSerial = value;
				} else {
					throw new Exception($"\tPassport serial number has wrong format!\n\t\"{value}\" is unacceptable!");
				}
			}
		}
		public string PassportPersonal {
			get => passportPersonal;
			set {
				if (PASS_PERSONAL_REGEX.IsMatch(value)) {
					passportPersonal = value;
				} else {
					throw new Exception($"\tPassport personal number has wrong format!\n\t\"{value}\" is unacceptable!");
				}
			}
		}
		public DateTime PassportDate {
			get => passportDate;
			set {
				passportDate = value;
			}
		}

		public PassportData() {
			PassportSerial = "KB" + rand.Next(1000000, 9999999).ToString();
			PassportPersonal = rand.Next(1000000, 9999999).ToString() + "M00" + rand.Next(0, 9).ToString() + "PB" + rand.Next(0, 9).ToString();
		}

		public override string ToString() {
			return $"{this.PassportSerial} {this.PassportPersonal}";
		}
	}
}

// TODO: Сделать дату выдачи паспорта и место выдачи
