using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Dto
{
    public class MovieDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
       
       
        public byte genre_Id { get; set; }

        public DateTime releaseDate { get; set; }
        public DateTime dateAdded { get; set; }
        [Range(1, 10)]
        public int StockNo { get; set; }
    }
}