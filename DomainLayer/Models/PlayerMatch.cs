using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class PlayerMatch
	{
		public int PlayerMatchId { get; set; }
		public bool IsSpare { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PersonId { get; set; }

		public virtual Match Match { get; set; }
		public virtual Team Team { get; set; }
		public virtual Person Person { get; set; }
	}
}
