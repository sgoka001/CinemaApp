using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class GenreMovieVM
    {

        public List<Movies> MoviesVM { get; set; }
        public List<Genres> GenresVM { get; set; }



        [Key]
        public string genreVM { get; set; }
        [Required]
        public int movieIdVM { get; set; }
        [Required]
        public string movies { get; set; }

    }
}
