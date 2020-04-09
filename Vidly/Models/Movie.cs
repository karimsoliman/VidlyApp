using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int StockNumber { get; set; }
        public Genre Genre {get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}