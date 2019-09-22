using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class Season
	{
		public int SeasonId { get; set; }
		public string Name { get; set; }

		// Relation 0..1
		public List<Match> Matches { get; set; }
	}
}
