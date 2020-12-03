using System;
using System.Text.RegularExpressions;

namespace NotaryTry2 {
	class Money {
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

		public Money(double val) => Value = Math.Round(val, 2);

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
			int dec = ((int)Math.Round(Value * 100)) % 100;
			string answer = ConvertIntegerPart(integer) + " " + ConvertDecimalPart(dec);
			
			return Regex.Replace(answer, @"\s+", " ");
		}

		private string GetEnding(int val, string[] arr) { // Выбирает правильное окончание для каждой сотни
			if (val % 100 > 10 && val % 100 < 20) {
				return arr[2];
			}
			if (val % 10 == 1) return arr[0];
			if (val % 10 > 1 && val % 10 < 5) return arr[1];
			return arr[2];
		}

		private string ConvertIntegerPart(int val) { // Конвертировать всю целую часть числа
			string answer = "";
			for(int i = 0; val > 0; i++, val /= 1000) {
				string temp = (i == 1)? ConvertHundredToString(val % 1000, PENNIES_UNITS) : ConvertHundredToString(val % 1000, RUBLES_UNITS);
				if (temp != RUBLES_UNITS[0] || i == 0) {
					temp += ' ' + GetEnding(val % 100,	RUBLES[i]);
				}
				answer = temp + ' ' + answer;
			}
			//Console.WriteLine(answer);
			return answer;
		}

		private string ConvertDecimalPart(int val) { // Конвертировать всю дробную часть числа
			return ConvertHundredToString(val, PENNIES_UNITS) + ' ' + GetEnding(val, PENNIES);
		}

		private string ConvertHundredToString(int val, string[] arr) { // Конвертировать тройку позиций числа
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

		public static Money operator +(Money a, Money b) => new Money(a.Value + b.Value);
		public static Money operator /(Money a, int div) => new Money(a.Value / div);
	}
}
