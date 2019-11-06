using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class TeamPlayer //: ITeamPlayerModel
	{
		public int TeamPlayerId { get; set; }
		public int? NumberPlayer { get; set; }
        public int TeamId { get; set; }
        public int PersonId { get; set; }
        public int? AmpluaId { get; set; }

		public virtual Team Team { get; set; }
		public virtual Person Person { get; set; }
		public virtual Amplua Amplua { get; set; }
	}
}
