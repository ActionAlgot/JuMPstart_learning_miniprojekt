using Las_OchSkrivhjalp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.DataAccess {
	public class QuestionsContext : DbContext {
		public QuestionsContext() : base("DefaultConnection") { }

		public DbSet<QuestionCategory> Categories { get; set; }
		public DbSet<WriteWordFromImage> WriteWordFromImageQuestions { get; set; }
		public DbSet<ComposeWordsToSentence> ComposeWordsToSentenceQuestions { get; set; }
		public DbSet<EditPunctuationOfWord> EditPunctuationOfWordQuestions { get; set; }
		public DbSet<PickColourFromText> PickColourFromTextQuestions { get; set; }
		public DbSet<Highscore> ScoreBoard { get; set; }
	}
}