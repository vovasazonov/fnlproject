using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class CommentatorMatch
	{
		public int CommentatorMatchId { get; set; }

		// Relation 1
		[Required]
		public Person Person { get; set; }
		// Relation 0..*
		public List<Match> Matches { get; set; }
	}
}
