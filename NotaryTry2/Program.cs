using System;
using Word = Microsoft.Office.Interop.Word;

namespace NotaryTry2 {
	class Program {
		
		static void Main(string[] args) {
			Random rand = new Random();

			for (int i = 0; i < 20; i++) {
				double val = rand.Next(0, 999999999) / 100.0;
				Console.WriteLine($"{val:0.00}\t{new MoneyConverter(val)}");
			}

			/*
			for(int i = 0; i < 20; i++) {
				double val = rand.Next(0, 99999) / 100.0;
				Console.WriteLine($"{val:0.00}\t{new MoneyConverter(val)}");
			}*/
			/*var wordApp = new Word.Application {
				Visible = true
			};
			var wordDoc2 = wordApp.Documents.Open(@"D:\Visual Studio\Projects\NotaryTry2\NotaryTry2\test_doc.docx");
			int amount = wordDoc2.Paragraphs.Count;
			Console.WriteLine(wordDoc2.Paragraphs.Count);
			for (int i = 1; i <= amount; i++) {
				Person p1 = new Person();
				MoneyConverter m1 = new MoneyConverter(rand.Next(0, 99999) / 100.0);

				Word.Paragraph par = wordDoc2.Paragraphs[i];
				Console.WriteLine(par.Range.Text);


				par.Range.Font.Name = "Times New Roman";
				par.Range.Font.Size = 13;
				par.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
				par.Range.Text = par.Range.Text.Replace("<name>", p1.GetFullName()).Replace("<sum>", m1.ToShortString()).Replace("<sumWord>", m1.ToString());
			}

			wordApp.Quit();*/
		}
	}
}

// TODO : При ручном выборе пола записывать в отдельный файл имя человека (система со временем научится отличать мужчину от женщины)