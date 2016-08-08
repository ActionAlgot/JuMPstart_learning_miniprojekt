using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Las_OchSkrivhjalp.DataAccess;
using Las_OchSkrivhjalp.Models;

namespace Las_OchSkrivhjalp.Repositories {
	public class QuestionRepo {
		private QuestionsContext db = new QuestionsContext();

		public IEnumerable<QuestionCategory> GetAllCategories() {
			return db.Categories;
		}

		public IEnumerable<Question> GetAllQuestions() {
			return db.Questions;
		}

		public QuestionCategory GetCategory(int id) {
			return db.Categories.SingleOrDefault(c => c.ID == id);
		}

		public Object /*json*/ GetQuestion(int id) {
			var qu = db.Questions.SingleOrDefault(q => q.ID == id);
			return qu == null ? null : qu.Ask();
		}

		public Object /*json*/ GetAnswerResult(int id, string answer) {
			var qu = db.Questions.SingleOrDefault(q => q.ID == id);
			return qu == null ? null : qu.Answer(answer);
		}

		public IEnumerable<Highscore> GetHighscores() {
			return db.ScoreBoard;
		}

		public void AddHighScore(Highscore hs) {
			db.ScoreBoard.Add(hs);
			while (db.ScoreBoard.Where(s => s.CategoryID == hs.CategoryID).Count() > 10)	//remove lowest score
				db.ScoreBoard.Remove(
					db.ScoreBoard.Where(s => s.CategoryID == hs.CategoryID)
					.Aggregate((a, b) => a.Score < b.Score ? a
						: a.Score > b.Score ? b
						: a.DateWhatever > b.DateWhatever ? a : b)
					);
			db.SaveChanges();
		}
	}
}