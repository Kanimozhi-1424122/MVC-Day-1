using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Day_1;

namespace MVC_Day_1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public Movies Movie1 { get; set; }
        public List<customer> Customers1 { get; set; }
        public customer Customers { get; set; }
        public List<Movies> Movie { get; set; }
    }
}