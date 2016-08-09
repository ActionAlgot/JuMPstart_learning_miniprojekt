namespace Las_OchSkrivhjalp.Migrations
{
	using Las_OchSkrivhjalp.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Las_OchSkrivhjalp.DataAccess.QuestionsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Las_OchSkrivhjalp.DataAccess.QuestionsContext context)
        {
			var cats = new List<QuestionCategory>(){
				new QuestionCategory{ID = 1, Name = "Ordet p� bilden", Questions = new List<Question>()},
				new QuestionCategory{ID = 2, Name = "Skriv meningen", Questions = new List<Question>()},
				new QuestionCategory{ID = 3, Name = "Skriv r�tt tecken", Questions = new List<Question>()},
				new QuestionCategory{ID = 4, Name = "V�lj r�tt f�rg", Questions = new List<Question>()}
			};

			var Scores = new List<Highscore>(){
				new Highscore{ID=1, Name ="Joel", DateWhatever= DateTime.Now, Score = Int32.MaxValue, CategoryID = 4}
			};

			var wwfiql = new List<WriteWordFromImage>(){
				new WriteWordFromImage{ID =1, Category = cats[0], Headline = "Skriv vad du ser", Hint = "", CorrectAnswer = "Anka", ImageSrc = "/Content/images/picture/anka.jpg"},
				new WriteWordFromImage{ID =2, Category = cats[0], Headline = "Skriv vad du ser", Hint = "", CorrectAnswer = "Bil", ImageSrc = "/Content/images/picture/bil.jpg"},
				new WriteWordFromImage{ID =3, Category = cats[0], Headline = "Skriv vad du ser", Hint = "", CorrectAnswer = "Boll", ImageSrc = "/Content/images/picture/Boll.jpg"},
				new WriteWordFromImage{ID =4, Category = cats[0], Headline = "Skriv vad du ser", Hint = "", CorrectAnswer = "Vas", ImageSrc = "/Content/images/picture/Vas.jpg"},
                new WriteWordFromImage{ID =5, Category = cats[0], Headline = "Skriv vad du ser", Hint = "", CorrectAnswer = "�pple", ImageSrc = "/Content/images/picture/�pple.jpg"}
			};
			
			var cwtsql = new List<ComposeWordsToSentence>(){
				new ComposeWordsToSentence{ID =1, Category = cats[1], Headline = "Skriv meningen", Hint = "", CorrectAnswer = "Inga fler d�liga bananer.", ImageSrc = "\Content\images\scrambeled\bananer.jpg"},
				new ComposeWordsToSentence{ID =2, Category = cats[1], Headline = "Skriv meningen", Hint = "", CorrectAnswer = "Alla barnen �r glada!", ImageSrc = "\Content/images/scrambeled/abarnen.jpg"},
				new ComposeWordsToSentence{ID =3, Category = cats[1], Headline = "Skriv meningen", Hint = "", CorrectAnswer = "En stor paj till middag.", ImageSrc = "/Content/images/scrambeled/middag.jpg"},
                new ComposeWordsToSentence{ID =4, Category = cats[1], Headline = "Skriv meningen", Hint = "", CorrectAnswer = "Var hittade han en cykel?", ImageSrc = "/Content/images/scrambeled/var_cykel.jpg"},
				new ComposeWordsToSentence{ID =5, Category = cats[1], Headline = "Skriv meningen", Hint = "", CorrectAnswer = "�r han en bra fotbollsspelare.", ImageSrc = "/Content/images/scrambeled/�r_fotbollsspelare.jpg"}
			};

			var epowql = new List<EditPunctuationOfWord>(){
				new EditPunctuationOfWord{ID =1, Category = cats[2], Headline = "Skriv r�tt tecken i meningen", Hint = "", CorrectAnswer = "Jag �r arg!", ImageSrc = "/Content/images/asterix/arg.jpg"},
				new EditPunctuationOfWord{ID =2, Category = cats[2], Headline = "Skriv r�tt tecken i meningen", Hint = "", CorrectAnswer = "Allt var bra,sa han.", ImageSrc = "/Content/images/asterix/bra.jpg"},
				new EditPunctuationOfWord{ID =3, Category = cats[2], Headline = "Skriv r�tt tecken i meningen", Hint = "", CorrectAnswer = "K�p flingor,fil,�pplen och sm�r", ImageSrc = "/Content/images/asterix/k�p_lista.jpg"},
				new EditPunctuationOfWord{ID =4, Category = cats[2], Headline = "Skriv r�tt tecken i meningen", Hint = "", CorrectAnswer = "Kom,skynda er!", ImageSrc = "/Content/images/asterix/skynda.jpg"},
                new EditPunctuationOfWord{ID =5, Category = cats[2], Headline = "Skriv r�tt tecken i meningen", Hint = "", CorrectAnswer = "�r du s�ker?", ImageSrc = "/Content/images/asterix/s�ker.jpg"}
			};

			var pcftql = new List<PickColourFromText>(){
				new PickColourFromText{ID =1, Category = cats[3], Headline = "Klicka p� r�tt f�rg", Hint = "", CorrectAnswer = "Bl�", ImageSrc = "Content/images/colors\bl�.jpg"},
				new PickColourFromText{ID =2, Category = cats[3], Headline = "Klicka p� r�tt f�rg", Hint = "", CorrectAnswer = "Gr�n", ImageSrc = "Content\images\colors\gr�n.jpg"},
				new PickColourFromText{ID =3, Category = cats[3], Headline = "Klicka p� r�tt f�rg", Hint = "", CorrectAnswer = "Gul", ImageSrc = "Content\images\colors\gul.jpg"},
				new PickColourFromText{ID =4, Category = cats[3], Headline = "Klicka p� r�tt f�rg", Hint = "", CorrectAnswer = "Orange", ImageSrc = "Content\images\colors\orange.jpg"},
                new PickColourFromText{ID =5, Category = cats[3], Headline = "Klicka p� r�tt f�rg", Hint = "", CorrectAnswer = "R�d", ImageSrc = "Content\images\colors\r�d.jpg"}
			};

			foreach (var c in cats) context.Categories.AddOrUpdate(c);
			foreach (var s in Scores) context.ScoreBoard.AddOrUpdate(s);
			foreach (var w in wwfiql) context.Questions.AddOrUpdate(w);
			foreach (var c in cwtsql) context.Questions.AddOrUpdate(c);
			foreach (var e in epowql) context.Questions.AddOrUpdate(e);
			foreach (var p in pcftql) context.Questions.AddOrUpdate(p);

			context.SaveChanges();
        }
    }
}
