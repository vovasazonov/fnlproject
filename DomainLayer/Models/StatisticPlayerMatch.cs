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
		public int MatchId { get; set; }
		public int PersonId { get; set; }

		public Match Match { get; set; }
		public Person Person { get; set; }
		public List<EventStatistic> EventStatistics { get; set; }
	}
}
