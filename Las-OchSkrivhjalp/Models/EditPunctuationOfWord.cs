using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.Models {
	public class EditPunctuationOfWord : IQuestion {
		public int ID { get; set; }

		public string AskedText { get; set; }
		public string Headline { get; set; }
		public string Hint { get; set; }

		public string CorrectAnswer { get; set; }

		public Object Ask() {
			return new { AskedText = AskedText, Headline = Headline, Hint = Hint };
		}

		public Object Answer(string answer) {
			int score = 0;
			for (int i = 0; i < ((answer.Length > CorrectAnswer.Length) ? answer.Length : CorrectAnswer.Length); i++) {
				if (AskedText[i] == '*') {
					if (answer[i] == CorrectAnswer[i]) score++;
				}
			}
			bool correct = answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
			return new { Correct = correct, points = score, CorrectAnswer = CorrectAnswer };
		}

		public int CategoryID { get; set; }
		public virtual QuestionCategory Category { get; set; }
	}
}