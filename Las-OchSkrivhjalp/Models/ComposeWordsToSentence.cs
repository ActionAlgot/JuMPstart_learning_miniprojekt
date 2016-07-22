using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.Models {
	public class ComposeWordsToSentence : IQuestion {
		public int ID { get; set; }

		public string ImageSrc { get; set; }
		public string Headline { get; set; }
		public string Hint { get; set; }

		public string CorrectAnswer { get; set; }

		public Object Ask() {
			return new { ImageSrc = ImageSrc, Headline = Headline, Hint = Hint };
		}

		public Object Answer(string answer) {
			string[] answerWords = answer.Split(new[] {' '});
			string[] correctWords = CorrectAnswer.Split(new[] {' '});
			int score = 0;
			for (int i = 0; i < (answerWords.Length > correctWords.Length ? answerWords.Length : correctWords.Length); i++) {
				if (answerWords[i] == correctWords[i]) score++;
			}
			bool correct = answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
			return new { Correct = correct, points = score, CorrectAnswer = CorrectAnswer };
		}

		public int CategoryID { get; set; }
		public virtual QuestionCategory Category { get; set; }
	}
}