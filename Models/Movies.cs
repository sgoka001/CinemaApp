using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Released { get; set; }
        public string Movie_Genre { get; set; }

        public virtual Genres Genre { get; set; }
    }
}
