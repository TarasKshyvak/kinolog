using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class KinologDbContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<MovieCreator> MovieCreators { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Creator> Creators { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public KinologDbContext(DbContextOptions<KinologDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Gender)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GenderId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(r => r.MoviesRatings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.UsersRatings)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Creators)
                .WithMany(c => c.Movies);

            modelBuilder.Entity<MovieCreator>()
                .HasOne(mc => mc.Position)
                .WithOne();

            modelBuilder.Entity<Creator>()
                .HasOne(cr => cr.Country)
                .WithMany(co => co.Creators)
                .HasForeignKey(cr => cr.CountryId);
        }
    }
}
