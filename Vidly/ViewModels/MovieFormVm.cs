using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormVm
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int? StockNumber { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public MovieFormVm()
        {
            Id = 0;
            StockNumber = 0;
            ReleaseDate = DateTime.MinValue;
        }

        public MovieFormVm(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            StockNumber = movie.StockNumber;
            GenreId = movie.GenreId;
        }

    }
}