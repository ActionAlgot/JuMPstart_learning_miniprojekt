using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Las_OchSkrivhjalp.Models {
	public class QuestionCategory {
		[Key]
		public int ID { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Question> Questions { get; set; }
	}
}