using System;

namespace NotaryTry2 {
	class Program {
		
		static void Main(string[] args) {
			Random rand = new Random();

			string date = "16/02/2018";
			var dt = new DateConverter(date);
			Console.WriteLine(dt.DT);
			
		}
	}
}

// TODO : При ручном выборе пола записывать в отдельный файл имя человека (система со временем научится отличать мужчину от женщины)