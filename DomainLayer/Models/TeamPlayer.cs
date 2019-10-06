using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class TeamPlayer
	{
		public int TeamPlayerId { get; set; }
		public int? NumberPlayer { get; set; }
        public int TeamId { get; set; }
        public int PersonId { get; set; }
        public int? AmpluaId { get; set; }

		public Team Team { get; set; }
		public Person Person { get; set; }
		public Amplua Amplua { get; set; }
	}
}
