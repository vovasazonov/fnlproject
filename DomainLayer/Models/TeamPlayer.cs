﻿using System;
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
		public int NumberPlayer { get; set; }

		// Relation 1
		public Team Team { get; set; }
		// Relation 1
		public Person Player { get; set; }
		// Relation 1
		public Amplua Amplua { get; set; }
	}
}
