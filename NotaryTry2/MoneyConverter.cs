using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NotaryTry2 {
	class MoneyConverter {
		private static readonly string[] PENNIES_UNITS = {"ноль", "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"};
		private static readonly string[] RUBLES_UNITS = {"ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"};
		private static readonly string[] DOZENS = { "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
		private static readonly string[] HUNDREDS = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
		private static readonly string[] EXCEPTION = {"", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"};

		private static readonly string[][] RUBLES = {new string[3] { "рубль", "рубля", "рублей" },
													 new string[3]{ "тысяча", "тысячи", "тысяч" },
													 new string[3]{ "миллион", "миллиона", "миллионов" }};
		private static readonly string[] PENNIES = {"копейка", "копейки", "копеек"};

		private double value;

		public MoneyConverter(double val) => Value = Math.Round(val, 2);

		public double Value {
			get => value;
			set { this.value = value; }
		}

		public string ToShortString() { // Выводит короткую запись суммы: 22 рубля 14 копеек
			int integer = (int)Math.Floor(Value);
			int dec = ((int)Math.Round(Value * 100)) % 100;
			return $"{integer} {GetEnding(integer, RUBLES[0])} {dec.ToString("00")} {GetEnding(dec, PENNIES)}";
		}

		public override string ToString() { // Выводит всю сумму прописью
			int integer = (int)Math.Floor(Value);
			int dec = ((int)Math.Round((Value - integer)*100)) % 100;
			string answer = ConvertIntegerPart(integer) + " " + ConvertDecimalPart(dec);
			
			return Regex.Replace(answer.Trim(), @"\s+", " ");
		}

		static private string GetEnding(int val, string[] arr) { // Выбирает правильное окончание для каждой сотни
			if (val % 100 > 10 && val % 100 < 20) {
				return arr[2];
			}
			if (val % 10 == 1) return arr[0];
			if (val % 10 > 1 && val % 10 < 5) return arr[1];
			return arr[2];
		}

		static private string ConvertIntegerPart(int val) { // Конвертирует всю целую часть числа
			List<string> answer = new List<string>();

			if (val == 0) {
				return ConvertHundredToString(val, RUBLES_UNITS) + " " + GetEnding(val, RUBLES[0]);
			}

			for (int i = 0; val > 0; i++, val /= 1000) {
				if ((val % 1000 != 0 || val / 1000 == 0)) {
					answer.Add(GetEnding(val % 100, RUBLES[i]));
					if (i == 1) {
						answer.Add(ConvertHundredToString(val % 1000, PENNIES_UNITS));
					} else {
						answer.Add(ConvertHundredToString(val % 1000, RUBLES_UNITS));
					}
				} else {
					if (i == 0) {
						answer.Add(GetEnding(val % 100, RUBLES[i]));
					}
				}
			}

			answer.Reverse();
			return string.Join(" ", answer);
		}

		static private string ConvertDecimalPart(int val) { // Конвертирует всю дробную часть числа
			return ConvertHundredToString(val, PENNIES_UNITS) + ' ' + GetEnding(val, PENNIES);
		}

		static private string ConvertHundredToString(int val, string[] arr) { // Конвертирует тройку позиций числа
			string answer = "";
			answer += HUNDREDS[val / 100];
			if (val % 100 > 10 && val % 100 < 20) {
				answer += ' ' + EXCEPTION[val % 10];
			} else {
				answer += ' ' + DOZENS[(val % 100) / 10];
				if ((string.IsNullOrWhiteSpace(answer) && val % 10 == 0) || val % 10 != 0) 
					answer += ' ' + arr[val % 10];
			}
			return answer;
		}

		public static MoneyConverter operator +(MoneyConverter a, MoneyConverter b) => new MoneyConverter(a.Value + b.Value);
		public static MoneyConverter operator /(MoneyConverter a, int div) => new MoneyConverter(a.Value / div);
	}
}
