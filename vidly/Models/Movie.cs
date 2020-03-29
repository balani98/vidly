using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Movie
    {    //these are properties of class
        public int id {get; set;}
        public string name { get; set; }
        public Genre genre { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime dateAdded { get; set; }
        public int StockNo { get; set; }
    }
}