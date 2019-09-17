using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainLayer.Models;

namespace DomainLayer
{
    public class DbFnlContext:DbContext
    {
		// In string the name of future database.
		public DbFnlContext() : base("DbFnl")
		{ }

		public DbSet<Person> People { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Stadium> Stadiums { get; set; }
		public DbSet<CommentatorMatch> CommentatorsMatches { get; set; }
		public DbSet<TeamPlayer> TeamPlayers { get; set; }
		public DbSet<StatisticPlayerMatch> StatisticsPlayersMatches { get; set; }
		public DbSet<EventStatistic> EventsStatistics { get; set; }
		public DbSet<Event> Events { get; set; }
	}
}
