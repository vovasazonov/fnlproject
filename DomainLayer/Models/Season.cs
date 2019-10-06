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
        [Required]
		public string Name { get; set; }

		public List<Match> Matches { get; set; }
	}
}
