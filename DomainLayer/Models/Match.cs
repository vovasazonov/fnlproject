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
	public class Match
	{
		public int MatchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
		public DateTime Date { get; set; }
        public int? StadiumId { get; set; }
        public int? SeasonId { get; set; }
        [ForeignKey("TeamGuest")]
        public int? TeamGuestId { get; set; }
        [ForeignKey("TeamOwner")]
        public int? TeamOwnerId { get; set; }

		public Stadium Stadium { get; set; }
		public Season Season { get; set; }
		public Team TeamOwner { get; set; }
		public Team TeamGuest { get; set; }
		public List<CommentatorMatch> CommentatorsMatch { get; set; }
		public List<StatisticPlayerMatch> Statistics { get; set; }
        public List<PlayerMatch> PlayersMatch { get; set; }
	}
}
