using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ModelLayer.Models;

namespace ModelLayer
{
    public class DbFnlContext:DbContext
    {
		// In string the name of database.
		public DbFnlContext() : base("DbFnl12")
		{ }

        public DbSet<Amplua> Ampluas { get; set; }
		public DbSet<FaceMatch> FacesMatches { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<EventStatistic> EventsStatistics { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Person> People { get; set; }
        public DbSet<PlayerMatch> PlayersMatches { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Season> Seasons { get; set; }
		public DbSet<Stadium> Stadiums { get; set; }
		public DbSet<StatisticPlayerMatch> StatisticsPlayersMatches { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<TeamPlayer> TeamPlayers { get; set; }
	}
}
