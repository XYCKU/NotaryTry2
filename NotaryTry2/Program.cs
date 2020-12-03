using System;

namespace NotaryTry2 {
	class Program {
		
		static void Main(string[] args) {
			Random rand = new Random();

			Money money = new Money(14.45);

			for(int i = 0; i < 10; i++) {
				double val = rand.Next(0, 78999) / 100.0;
				Console.WriteLine($"{val}\t{new Money(val)}\n");
			}

		}
	}
}

// TODO : При ручном выборе пола записывать в отдельный файл имя человека (система со временем научится отличать мужчину от женщины)