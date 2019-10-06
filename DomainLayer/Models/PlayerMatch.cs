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
        [Required]
		public bool IsSpare { get; set; }
        [Required]
        public int MatchId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int PersonId { get; set; }

		public Match Match { get; set; }
		public Team Team { get; set; }
		public Person Person { get; set; }
	}
}
