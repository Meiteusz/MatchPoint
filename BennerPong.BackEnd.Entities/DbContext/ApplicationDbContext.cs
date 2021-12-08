using MatchPoint.BackEnd.GameAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchPoint.BackEnd.GameAPI.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Player> players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                        .HasOne(a => a.Score)
                        .WithOne(b => b.Game)
                        .HasForeignKey<Score>(c => c.GameId);

            //rodar esses manos pra em uma nova migração para que as shadow properties sejam criadas (temos que configurar elas tbm)
            modelBuilder.Entity<Game>().Property<DateTime>("CreatedPlayer");
            modelBuilder.Entity<Game>().Property<DateTime>("UpdatedPlayer");

            modelBuilder.Entity<Game>().Property<int>("CreatedPlayer");
            modelBuilder.Entity<Game>().Property<int>("UpdatedPlayer");

            base.OnModelCreating(modelBuilder);
        }
    }
}
