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
				new QuestionCategory{ID = 1, Name = "Write word from image", Questions = new List<IQuestion>()},
				new QuestionCategory{ID = 2, Name = "Compose words to sentence", Questions = new List<IQuestion>()},
				new QuestionCategory{ID = 3, Name = "Edit punctuation of word", Questions = new List<IQuestion>()},
				new QuestionCategory{ID = 4, Name = "Pick colour from text", Questions = new List<IQuestion>()}
			};

			var Scores = new List<Highscore>(){
				new Highscore{ID=1, Name ="Joel", DateWhatever= DateTime.Now, Score = Int32.MaxValue, CategoryID = 4}
			};

			var wwfiql = new List<WriteWordFromImage>(){
				new WriteWordFromImage{ID =1, CategoryID = 1, Headline = "Write word from image", Hint = "", CorrectAnswer = "", ImageSrc = ""},
				new WriteWordFromImage{ID =2, CategoryID = 1, Headline = "Write word from image", Hint = "", CorrectAnswer = "asdf", ImageSrc = ""},
				new WriteWordFromImage{ID =3, CategoryID = 1, Headline = "Write word from image", Hint = "", CorrectAnswer = "", ImageSrc = ""},
				new WriteWordFromImage{ID =4, CategoryID = 1, Headline = "Write word from image", Hint = "", CorrectAnswer = "foobary", ImageSrc = ""}
			};

			var cwtsql = new List<ComposeWordsToSentence>(){
				new ComposeWordsToSentence{ID =1, CategoryID = 2, Headline = "Compose the words into a proper sentence", Hint = "", CorrectAnswer = "", ImageSrc = ""},
				new ComposeWordsToSentence{ID =2, CategoryID = 2, Headline = "Compose the words into a proper sentence", Hint = "AAAAAAH", CorrectAnswer = "666", ImageSrc = ""},
				new ComposeWordsToSentence{ID =3, CategoryID = 2, Headline = "Compose the words into a proper sentence", Hint = "INGEN JESUS KRIST I VÅR SVARTA PIST", CorrectAnswer = "INGEN JESUS KRIST I VÅR SVARTA PIST", ImageSrc = ""},
				new ComposeWordsToSentence{ID =4, CategoryID = 2, Headline = "Compose the words into a proper sentence", Hint = "", CorrectAnswer = "foobary", ImageSrc = ""}
			};

			var epowql = new List<EditPunctuationOfWord>(){
				new EditPunctuationOfWord{ID =1, CategoryID = 3, Headline = "Replace asterix' with proper punctuation", Hint = "HAIL SATAN", CorrectAnswer = "This is a question?", AskedText = "This is a question*"},
				new EditPunctuationOfWord{ID =2, CategoryID = 3, Headline = "Replace asterix' with proper punctuation", Hint = "", CorrectAnswer = "This is a question?", AskedText = "This is a question*"},
				new EditPunctuationOfWord{ID =3, CategoryID = 3, Headline = "Replace asterix' with proper punctuation", Hint = "", CorrectAnswer = "This is a question?", AskedText = "This is a question*"},
				new EditPunctuationOfWord{ID =4, CategoryID = 3, Headline = "Replace asterix' with proper punctuation", Hint = "", CorrectAnswer = "This is a question?", AskedText = "This is a question*"}
			};

			var pcftql = new List<PickColourFromText>(){
				new PickColourFromText{ID =1, CategoryID = 4, Headline = "Write word from image", Hint = "", CorrectAnswer = "Torquise", Colortxtxtxt = "Torquise"},
				new PickColourFromText{ID =2, CategoryID = 4, Headline = "Write word from image", Hint = "", CorrectAnswer = "Turdquise", Colortxtxtxt = "Torquise"},
				new PickColourFromText{ID =3, CategoryID = 4, Headline = "Write word from image", Hint = "", CorrectAnswer = "Black",  Colortxtxtxt = "Black"},
				new PickColourFromText{ID =4, CategoryID = 4, Headline = "Write word from image", Hint = "", CorrectAnswer = "Pink",  Colortxtxtxt = "Pink"}
			};

			foreach (var c in cats) context.Categories.AddOrUpdate(c);
			foreach (var s in Scores) context.ScoreBoard.AddOrUpdate(s);
			foreach (var w in wwfiql) context.WriteWordFromImageQuestions.AddOrUpdate(w);
			foreach (var c in cwtsql) context.ComposeWordsToSentenceQuestions.AddOrUpdate(c);
			foreach (var e in epowql) context.EditPunctuationOfWordQuestions.AddOrUpdate(e);
			foreach (var p in pcftql) context.PickColourFromTextQuestions.AddOrUpdate(p);

			context.SaveChanges();
        }
    }
}
