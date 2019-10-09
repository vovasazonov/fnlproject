using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class Amplua
	{
		public int AmpluaId { get; set; }
        [Required]
		public string Name { get; set; }

		public virtual List<TeamPlayer> Players { get; set; }
	}
}
