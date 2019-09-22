using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	/// <summary>
	/// Say what is the role of person in position value.
	/// It can be like commentator, judje, attcker, defender and etc.
	/// </summary>
	public class Person
	{
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string PhotoPath { get; set; } 
		public Address Address { get; set; }

		// Relation 1
		[Required]
		public Role Position { get; set; }
		// Relation 0..1
		public TeamPlayer TeamPlayer { get; set; }
		// Relation 0..1
		public CommentatorMatch CommentatorMatch { get; set; }
		// Relation 0..*
		public List<StatisticPlayerMatch> Statistics { get; set; }

	}
}
