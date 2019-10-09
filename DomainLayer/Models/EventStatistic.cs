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
	/// Concret event that appear in concret time.
	/// </summary>
	public class EventStatistic
	{
		public int EventStatisticId { get; set; }
		[Required]
		public DateTime Time { get; set; }
		[Required]
		public int HalfMatch { get; set; }
        public int StatisticPlayerMatchId { get; set; }
        public int EventId { get; set; }

        public virtual StatisticPlayerMatch StatisticPlayerMatch { get; set; }
		public virtual Event Event { get; set; }
	}
}
