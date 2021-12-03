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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                        .HasOne(a => a.Score)
                        .WithOne(b => b.Game)
                        .HasForeignKey<Score>(c => c.GameId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
