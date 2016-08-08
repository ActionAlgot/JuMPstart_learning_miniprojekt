using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.Models {
	public class PickColourFromText : Question {
		public override Object Answer(string answer) {
			bool correct = answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
			return new { Correct = correct, points = correct ? 1 : 0, CorrectAnswer = CorrectAnswer };
		}
	}
}