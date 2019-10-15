using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Day_1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day_1
{
    public class Movies
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="MovieName cannot be empty")]
        [Display(Name="Movie Name")]
        [StringLength(50)]
        public string  MovieName { get; set; }

        // public string DirectorName { get; set; }  
        [Required(ErrorMessage ="Actor name cannot be enpty")]
        [Display(Name = "Actor Name")]
        public string ActorName { get; set; }

        [Required(ErrorMessage ="Release Date is Required")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage ="Available stocks is needed")]
        [Display(Name = "Available Stocks")]
        public int? AvailableStocks { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public int? GenreId { get; set; }
      
    }
}