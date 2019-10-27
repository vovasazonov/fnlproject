using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
	public class Event
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }
        [Required]
		public string Name { get; set; }

		public virtual List<EventStatistic> EventStatistics { get; set; }
	}
}
