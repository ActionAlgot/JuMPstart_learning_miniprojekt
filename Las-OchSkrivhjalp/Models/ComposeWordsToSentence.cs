using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.Models {
	public class ComposeWordsToSentence : Question {
		public override Object Answer(string answer) {
			string[] answerWords = answer.Split(new[] {' '});
			string[] correctWords = CorrectAnswer.Split(new[] {' '});
			int score = 0;
			for (int i = 0; i < (answerWords.Length > correctWords.Length ? answerWords.Length : correctWords.Length); i++) {
				if (answerWords[i] == correctWords[i]) score++;
			}
			bool correct = answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
			return new { Correct = correct, points = score, CorrectAnswer = CorrectAnswer };
		}
	}
}