using System;

namespace NotaryTry2 {
	class Program {
		
		static void Main(string[] args) {
			Random rand = new Random();

			string date = "/01/2018";
			for(int i = 1; i < 32; i++) {
				new DateConverter($"{i}{date}");
			}
		}
	}
}

// TODO : При ручном выборе пола записывать в отдельный файл имя человека (система со временем научится отличать мужчину от женщины)