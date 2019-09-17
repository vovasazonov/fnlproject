using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class Address
	{
		public string Country { get; set; }
		public string City { get; set; }
	}
}
