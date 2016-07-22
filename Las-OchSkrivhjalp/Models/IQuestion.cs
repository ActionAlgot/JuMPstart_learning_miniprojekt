using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Las_OchSkrivhjalp.Models {
	public interface IQuestion {
		[Key]
		int ID { get; set; }

		//Object to be parsed to Json
		Object Ask();
		Object Answer(string answer);	//correct, points, correct answer

		[ForeignKey("Category")]
		int CategoryID { get; set; }
		/*virtual*/ QuestionCategory Category { get; set; }
	}
}
