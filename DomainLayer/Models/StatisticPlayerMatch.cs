using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	/// <summary>
	/// Statistic of player in current match
	/// </summary>
	public class StatisticPlayerMatch
	{
		public int StatisticPlayerMatchId { get; set; }
		
		// Relation 1
		[Required]
		public Match Match { get; set; }
		// Relation 1
		[Required]
		public Person Person { get; set; }
		// Relation 1..*
		[Required]
		public List<EventStatistic> EventStatistics { get; set; }
		// Relation 1
		[Required]
		public Event Event { get; set; }
	}
}
