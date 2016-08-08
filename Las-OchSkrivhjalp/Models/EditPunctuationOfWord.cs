using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.Models {
	public class EditPunctuationOfWord : Question {
		public override Object Answer(string answer) {
			int score = 0;
			for (int i = 0; i < ((answer.Length > CorrectAnswer.Length) ? answer.Length : CorrectAnswer.Length); i++) {
				if (Hint[i] == '*') {
					if (answer[i] == CorrectAnswer[i]) score++;
				}
			}
			bool correct = answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
			return new { Correct = correct, points = score, CorrectAnswer = CorrectAnswer };
		}
	}
}