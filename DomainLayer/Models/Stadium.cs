using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class Stadium
	{
		public int StadiumId { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }

		// Relation 0..*
		public List<Match> Matches { get; set; }
	}
}
