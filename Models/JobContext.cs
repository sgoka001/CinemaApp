using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaApp.Models
{
    public partial class JobContext : DbContext
    {
        public JobContext() { }
        public JobContext(DbContextOptions<JobContext> options) : base(options) { }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(database connection string);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.HasOne(d => d.Genre);

                entity.Property(e => e.MovieId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.Genre);

                entity.HasMany(e => e.Movies);
            });

            //seed
            modelBuilder.Entity<Genres>().HasData(
                new Genres() { Genre = "Sci-Fi" },
                new Genres() { Genre = "Comedy" },
                new Genres() { Genre = "Sad" }
                );

            modelBuilder.Entity<Movies>().HasData(
                new Movies() { MovieId = 1, Name = "Harry Potter 1", Released = 2019, Movie_Genre = "Sci-Fi" },
                new Movies() { MovieId = 2, Name = "Harry Potter 2", Released = 2018, Movie_Genre = "Sci-Fi" },
                new Movies() { MovieId = 3, Name = "Harry Potter 3", Released = 2017, Movie_Genre = "Sci-Fi" },
                new Movies() { MovieId = 4, Name = "Bruce Almighty", Released = 2017, Movie_Genre = "Comedy" },
                new Movies() { MovieId = 5, Name = "Titanic", Released = 2017, Movie_Genre = "Sad" }

                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
