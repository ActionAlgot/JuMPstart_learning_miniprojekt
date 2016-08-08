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
				new QuestionCategory{ID = 1, Name = "Write word from image", Questions = new List<Question>()},
				new QuestionCategory{ID = 2, Name = "Compose words to sentence", Questions = new List<Question>()},
				new QuestionCategory{ID = 3, Name = "Edit punctuation of word", Questions = new List<Question>()},
				new QuestionCategory{ID = 4, Name = "Pick colour from text", Questions = new List<Question>()}
			};

			var Scores = new List<Highscore>(){
				new Highscore{ID=1, Name ="Joel", DateWhatever= DateTime.Now, Score = Int32.MaxValue, CategoryID = 4}
			};

			var wwfiql = new List<WriteWordFromImage>(){
				new WriteWordFromImage{ID =1, Category = cats[0], Headline = "Write word from image", Hint = "", CorrectAnswer = "", ImageSrc = ""},
				new WriteWordFromImage{ID =2, Category = cats[0], Headline = "Write word from image", Hint = "", CorrectAnswer = "asdf", ImageSrc = ""},
				new WriteWordFromImage{ID =3, Category = cats[0], Headline = "Write word from image", Hint = "", CorrectAnswer = "", ImageSrc = ""},
				new WriteWordFromImage{ID =4, Category = cats[0], Headline = "Write word from image", Hint = "", CorrectAnswer = "foobary", ImageSrc = ""}
			};

			var cwtsql = new List<ComposeWordsToSentence>(){
				new ComposeWordsToSentence{ID =1, Category = cats[1], Headline = "Compose the words into a proper sentence", Hint = "", CorrectAnswer = "", ImageSrc = ""},
				new ComposeWordsToSentence{ID =2, Category = cats[1], Headline = "Compose the words into a proper sentence", Hint = "AAAAAAH", CorrectAnswer = "666", ImageSrc = ""},
				new ComposeWordsToSentence{ID =3, Category = cats[1], Headline = "Compose the words into a proper sentence", Hint = "INGEN JESUS KRIST I VÅR SVARTA PIST", CorrectAnswer = "INGEN JESUS KRIST I VÅR SVARTA PIST", ImageSrc = ""},
				new ComposeWordsToSentence{ID =4, Category = cats[1], Headline = "Compose the words into a proper sentence", Hint = "", CorrectAnswer = "foobary", ImageSrc = ""}
			};

			var epowql = new List<EditPunctuationOfWord>(){
				new EditPunctuationOfWord{ID =1, Category = cats[2], Headline = "Replace asterix' with proper punctuation", Hint = "HAIL SATAN", CorrectAnswer = "This is a question?", ImageSrc = ""},
				new EditPunctuationOfWord{ID =2, Category = cats[2], Headline = "Replace asterix' with proper punctuation", Hint = "", CorrectAnswer = "This is a question?", ImageSrc = ""},
				new EditPunctuationOfWord{ID =3, Category = cats[2], Headline = "Replace asterix' with proper punctuation", Hint = "", CorrectAnswer = "This is a question?", ImageSrc = ""},
				new EditPunctuationOfWord{ID =4, Category = cats[2], Headline = "Replace asterix' with proper punctuation", Hint = "", CorrectAnswer = "This is a question?", ImageSrc = ""}
			};

			var pcftql = new List<PickColourFromText>(){
				new PickColourFromText{ID =1, Category = cats[3], Headline = "Write word from image", Hint = "", CorrectAnswer = "Torquise", ImageSrc = "Torquise"},
				new PickColourFromText{ID =2, Category = cats[3], Headline = "Write word from image", Hint = "", CorrectAnswer = "Turdquise", ImageSrc = "Torquise"},
				new PickColourFromText{ID =3, Category = cats[3], Headline = "Write word from image", Hint = "", CorrectAnswer = "Black",  ImageSrc = "Black"},
				new PickColourFromText{ID =4, Category = cats[3], Headline = "Write word from image", Hint = "", CorrectAnswer = "Pink",  ImageSrc = "Pink"}
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
