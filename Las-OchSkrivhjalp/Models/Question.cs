using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Las_OchSkrivhjalp.Models {
	public abstract class Question {
		[Key]
		public int ID { get; set; }

		public string ImageSrc { get; set; }
		public string Headline { get; set; }
		public string Hint { get; set; }

		public string CorrectAnswer { get; set; }

		//Object to be parsed to Json
		public Object Ask() {
			return new { ImageSrc = ImageSrc, Headline = Headline, Hint = Hint };
		}
		public abstract Object Answer(string answer);	//correct, points, correct answer

		[ForeignKey("Category")]
		public int CategoryID { get; set; }
		public virtual QuestionCategory Category { get; set; }
	}
}
