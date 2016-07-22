using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Las_OchSkrivhjalp.Models {
	public class Highscore {
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public int Score { get; set; }
		public DateTime DateWhatever { get; set; }

		[ForeignKey("Category")]
		public int? CategoryID { get; set; }	//null for mixed questions because we're lazy fucks
		public virtual QuestionCategory Category {get; set;}
	}
}