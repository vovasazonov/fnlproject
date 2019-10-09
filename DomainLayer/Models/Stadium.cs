using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class Stadium
	{
		public int StadiumId { get; set; }
        [Required]
		public string Name { get; set; }
		public Address Address { get; set; }

		public virtual List<Match> Matches { get; set; }
	}
}
