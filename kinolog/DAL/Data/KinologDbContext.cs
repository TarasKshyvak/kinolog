using System.Collections.Generic;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL.Data
{
    public class KinologDbContext : DbContext
    {
        public KinologDbContext(DbContextOptions<KinologDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>().ToTable("BaseEntity");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Creator>().ToTable("Creator");
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");
                entity.HasMany(u => u.Users)
                .WithOne(g => g.Gender);
            });
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<MovieCreator>().ToTable("MovieCreator");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasOne(g => g.Gender)
                .WithMany(u => u.Users);
                //entity.HasMany(r => r.Ratings)
                //.WithOne(u => u.Users);
            });

                
                
            

        }


        public virtual DbSet<BaseEntity>? BaseEntities { get; set; }
        public virtual DbSet<Country>? Countries { get; set; }
        public virtual DbSet<Creator>? Creators { get; set; }
        public virtual DbSet<Gender>? Genders { get; set; }
        public virtual DbSet<Genre>? Genres { get; set; }
        public virtual DbSet<Movie>? Movies { get; set; }
        public virtual DbSet<MovieCreator>? MovieCreators { get; set; }
        public virtual DbSet<Position>? Positions { get; set; }
        public virtual DbSet<Rating>? Ratings { get; set; }
        public virtual DbSet<User>? Users { get; set; }


    }
}
