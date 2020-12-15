using System;

namespace NotaryTry2 {
	class Program {
		
		static void Main(string[] args) {
			Random rand = new Random();

			for(int i = 0; i < 20; i++) {
				double val = rand.Next(0, 99999) / 100.0;
				Console.WriteLine($"{val:0.00}\t{new MoneyConverter(val)}");
			}
		}
	}
}

// TODO : При ручном выборе пола записывать в отдельный файл имя человека (система со временем научится отличать мужчину от женщины)