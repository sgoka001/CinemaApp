using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Movies = new List<Movies>();
        }

        [Key]
        [StringLength(50)]
        public string Genre { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}