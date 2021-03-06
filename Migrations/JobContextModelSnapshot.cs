﻿// <auto-generated />
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaApp.Migrations
{
    [DbContext(typeof(JobContext))]
    partial class JobContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaApp.Models.GenreMovieVM", b =>
                {
                    b.Property<string>("genreVM")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("movieIdVM")
                        .HasColumnType("int");

                    b.Property<string>("movies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("genreVM");

                    b.ToTable("GenreMovieVM");
                });

            modelBuilder.Entity("CinemaApp.Models.Genres", b =>
                {
                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("GenreMovieVMgenreVM")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Genre");

                    b.HasIndex("GenreMovieVMgenreVM");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("CinemaApp.Models.Movies", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Genre1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GenreMovieVMgenreVM")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Movie_Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Released")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("Genre1");

                    b.HasIndex("GenreMovieVMgenreVM");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CinemaApp.Models.Genres", b =>
                {
                    b.HasOne("CinemaApp.Models.GenreMovieVM", null)
                        .WithMany("GenresVM")
                        .HasForeignKey("GenreMovieVMgenreVM");
                });

            modelBuilder.Entity("CinemaApp.Models.Movies", b =>
                {
                    b.HasOne("CinemaApp.Models.Genres", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("Genre1");

                    b.HasOne("CinemaApp.Models.GenreMovieVM", null)
                        .WithMany("MoviesVM")
                        .HasForeignKey("GenreMovieVMgenreVM");
                });
#pragma warning restore 612, 618
        }
    }
}
