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

		// Relation 1
		public Match Match { get; set; }
		// Relation 1
		public Team Team { get; set; }
		// Relation 1
		public Person Player { get; set; }
	}
}
