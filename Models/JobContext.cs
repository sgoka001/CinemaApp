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

        public virtual DbSet<GenreMovieVM> GenreMovieVM { get; set; }

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

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.Genre);

                entity.HasMany(e => e.Movies);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.HasOne(d => d.Genre);

                entity.Property(e => e.MovieId).ValueGeneratedNever();
            });

            modelBuilder.Entity<GenreMovieVM>(entity =>
            {
                entity.HasKey(e => e.genreVM);

                entity.Property(e => e.genreVM).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
