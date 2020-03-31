using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Movie
    {
        //these are properties of class
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public Genre genre { get; set; }
        public byte genre_Id { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime dateAdded { get; set; }
        public int StockNo { get; set; }
    }
}