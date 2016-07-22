using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Las_OchSkrivhjalp.Models {
	public class WriteWordFromImage : IQuestion {
		public int ID { get; set; }

		public Object Ask() {
			throw new NotImplementedException();
		}

		public Object Answer(string answer) {
			throw new NotImplementedException();
		}

		public int CategoryID { get; set; }
		public virtual QuestionCategory Category { get; set; }
	}
}