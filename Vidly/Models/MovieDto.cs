using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int StockNumber { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}