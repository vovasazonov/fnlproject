using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class Match
	{
		public int MatchId { get; set; }
		public DateTime Date { get; set; }

		// Relation 1
		[Required]
		public Stadium Stadium { get; set; }
		// Relation 1..0
		public Season Season { get; set; }
		// Relation 0..*
		public List<CommentatorMatch> CommentatorsMatch { get; set; }
		// Relation 1..0
		public Team TeamOwner { get; set; }
		// Relation 1..0
		public Team TeamGuest { get; set; }
		// Relation 0..*
		public List<StatisticPlayerMatch> Statistics { get; set; }
	}
}
