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
		//public DbSet<IQuestion> Questions { get; set; }
		public DbSet<Highscore> ScoreBoard { get; set; }
	}
}