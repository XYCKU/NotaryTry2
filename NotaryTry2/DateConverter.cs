﻿using System;
using System.Text.RegularExpressions;

namespace NotaryTry2 {
	class DateConverter {
		private static readonly string[] MONTHS = { "", "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря",  };
		private static readonly string[] DAYS_UNITS = { "", "первого", "второго", "третьего", "четвертого", "пятого", "шестого", "седьмого", "восьмого", "девятого", "десятого", 
														"одиннадцатого", "двенадцатого", "тринадцатого", "четырнадцатого", "пятнадцатого", "шестнадцатого", "семнадцатого", "восемнадцатого", "девятнадцатого", 
														"двадцатого", "двадцать", "двадцать", "двадцать", "двадцать", "двадцать", "двадцать", "двадцать", "двадцать", "двадцать", "тридцатого", "тридцать" };
		private static readonly string[] YEAR_THOUSANDS = { "", "одна", "две" };
		private static readonly string[] YEAR_HUNDREDS = { "", "", "", "", "", "", "", "", "", "девятьсот", };
		private static readonly string[] YEARS = { "", "первого", "второго", "третьего", "четвертого", "пятого", "шестого", "седьмого", "восьмого", "девятого", };

		private DateTime dt;

		public DateTime DT {
			get => dt;
			set {
				dt = value;
			}
		}
		public DateConverter() {
			DT = new DateTime();
			
		}
		public DateConverter(string dateString) { // Конструктор
			if (DateTime.TryParse(dateString, out DateTime result)) {
				DT = result;
			} else {
				throw new Exception($"\tDate has wrong format!\n\t\"{dateString}\" is unacceptable!");
			}
			Console.WriteLine(ConvertDay(DT.Day) + ' ' + ConvertMonth(DT.Month));
		}
		private string ConvertDay(int val) { // Преобразует день в слова
			if (val > 10 && val < 20) {
				return DAYS_UNITS[val];
			}
			if (val > 9) {
				return DAYS_UNITS[val] + ' ' + DAYS_UNITS[val % 10];
			} else {
				return DAYS_UNITS[val % 10];
			}
		}
		private string ConvertMonth(int val) { // Преобразует месяц в слово
			return MONTHS[val];
		}
	}
}
