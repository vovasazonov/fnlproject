using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class Amplua
	{
		public int AmpluaId { get; set; }
		public string Name { get; set; }

		// Relation 0..*
		public List<TeamPlayer> Players { get; set; }
	}
}
