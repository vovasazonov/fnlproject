using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
	public class Amplua
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AmpluaId { get; set; }
        [Required]
		public string Name { get; set; }

		public virtual List<TeamPlayer> Players { get; set; }
	}
}
