using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    //This is Class Library as well as Models Project is, only the startup project is Console App!
    //Install following NuGet Packages here!

    //Microsoft.EntityFrameworkCore - 3.1.3
    //Microsoft.EntityFrameworkCore.SqlServer - 3.1.3
    //Microsoft.EntityFrameworkCore.Tools - 3.1.3
    public class FootballBettingContext : DbContext
    {
        //1)
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }
        // DbSet - we make records of all DB sets we have in Models - which are our tables
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }



        //2) - Establish Connection to SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Integrated Security=true;Database=FootballBettingSystem;TrustServerCertificate=Yes;");
            }
        }

        //3)
        //Defines rules for creating Data-Base
        //We can define any Composite PK of mapping Entity here.
        //We need to add in Dependencies reference of "P03_FootballBetting.Data.Models" to see all Models we need , make the Usings
        //Define Delete behavior so that we can make Migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new { ps.GameId, ps.PlayerId }); // HasKey - defines a PK , which we set as composite PK by Linq function over new object consisted of 2 properties { e.GameId, e.PlayerId }
            });  // this PK is now an Object of several PK

            //When we have 2 or more references as FK to other table we need to describe tables with such connections with modelBuilder , with reference to their OnDelete behavior! Our case we need on delete to do nothing ,otherwise we can delete cascade whole data-base!
            modelBuilder.Entity<Team>(e =>
            {
                e.HasOne(t => t.PrimaryKitColor) //we take it fm Table Team One Navigation Property type Color
                .WithMany(c => c.PrimaryKitTeams) //we take it fm Table Color Collection of many PrimaryKitTeams
                .HasForeignKey(t => t.PrimaryKitColorId) // fk
                .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(t => t.SecondaryKitColor) //we take it fm Table Team One Navigation Property type Color
                .WithMany(c => c.SecondaryKitTeams) //we take it fm Table Color Collection of many PrimaryKitTeams
                .HasForeignKey(t => t.SecondaryKitColorId) // fk
                .OnDelete(DeleteBehavior.NoAction);

            });
            //Same problem with all tables including this table about 2 or more relations to another table ,so delete behavior must be declared here!
            modelBuilder.Entity<Game>(g =>
            {
                g.HasOne(t => t.HomeTeam)
                 .WithMany(g => g.HomeGames)
                 .HasForeignKey(t => t.HomeTeamId)
                 .OnDelete(DeleteBehavior.NoAction);

                g.HasOne(t => t.AwayTeam)
                .WithMany(g => g.AwayGames)
                .HasForeignKey(t => t.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            });

        }
    }
}
