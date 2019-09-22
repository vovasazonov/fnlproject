using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	public class Role
	{
		public int RoleId { get; set; }
		[Required]
		public string Name { get; set; }

		// Relation 0..*
		public List<Person> People { get; set; }
	}
}
