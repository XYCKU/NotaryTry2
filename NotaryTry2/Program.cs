using System;

namespace NotaryTry2 {
	class Program {
		
		static void Main(string[] args) {
			Random rand = new Random();

			Money money = new Money(14.45);

			for(int i = 0; i < 10; i++) {
				double val = rand.Next(0, 100000) / 100.0;
				//double val = 530.43;
				Console.WriteLine($"{val.ToString("0.00")}\t{new Money(val).ToShortString()}");
			}
			Console.WriteLine();
			for(int i = 0; i < 10; i++) {
				double val = rand.Next(0, 100000000) / 100.0;
				//double val = 530.43;
				Console.WriteLine($"{val}\t{new Money(val)}");
			}
			Console.WriteLine();
			for (int i = 0; i < 10; i++) {
				double val = rand.Next(0, 99999999) * 10 / 100.0;
				//double val = 530.43;
				Console.WriteLine($"{val}\t{new Money(val)}");
			}
			

		}
	}
}

// TODO : При ручном выборе пола записывать в отдельный файл имя человека (система со временем научится отличать мужчину от женщины)