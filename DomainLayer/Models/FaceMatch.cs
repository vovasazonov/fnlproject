using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class FaceMatch
	{
		public int FaceMatchId { get; set; }
        public int PersonId { get; set; }
        public int MatchId { get; set; }

		public virtual Person Person { get; set; }
		public virtual List<Match> Matches { get; set; }
	}
}
