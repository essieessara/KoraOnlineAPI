using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KoraOnlineAPI.Models
{
    public partial class KoraOnline : DbContext
    {
        public KoraOnline()
        {
        }

        public KoraOnline(DbContextOptions<KoraOnline> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Punishment> Punishments { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Stadium> Stadia { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Finalproject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_city_country");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_goals_match_master");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_goals_player");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_goals_team");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.MatchId).ValueGeneratedNever();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK_match_master_league");

                entity.HasOne(d => d.Staduim)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StaduimId)
                    .HasConstraintName("FK_match_master_stadium");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasOne(d => d.League)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK_news_league");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_news_match_master");

                entity.HasOne(d => d.NewsCategory)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.NewsCategoryId)
                    .HasConstraintName("FK_news_Category");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_news_player");

                entity.HasOne(d => d.Stad)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.StadId)
                    .HasConstraintName("FK_news_stadium");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_news_team");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_player_team1");
            });

            modelBuilder.Entity<Punishment>(entity =>
            {
                entity.Property(e => e.PunishId).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Punishments)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_punishment_player");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.TeamId });

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_result_match_master");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_result_team");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.Property(e => e.StadiumId).ValueGeneratedNever();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Stadia)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_studium_city");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).ValueGeneratedNever();

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK_team_coach");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK_team_league");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
