using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Day_1;
using MVC_Day_1.ViewModel;
using MVC_Day_1.Models;
using System.Data.Entity;
namespace MVC_Day_1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext dbContext = null;
        public MovieController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        public ActionResult Index()
        {
            List<Movies> movies = dbContext.movies.Include(K => K.Genre).ToList();
            return View(movies);
        }
        //public ActionResult DisplayMovie()
        //{
        //    CustomerMovieViewModel CustomerDetailsViewModel = new CustomerMovieViewModel();
        //    Movies movie = new Movies { Name = "BIGIL", DirectorName = "Atlee", ActorName = "Vijay" };

        //    List<customer> customers = new List<customer>
        //    {
        //         new customer{customerName="Kanimozhi"},
        //         new customer { customerName="Kalpana"},
        //         new customer{customerName="Arthi"},
        //         new customer{customerName="Usha"},
        //         new customer { customerName="Raga"}
        //    };
        //    CustomerDetailsViewModel.Movie1 = movie;
        //    CustomerDetailsViewModel.Customers1 = customers;
        //    return View(CustomerDetailsViewModel);
        //}
        //public ActionResult DisplayCustomer()
        //{
        //    CustomerMovieViewModel MovieDetail = new CustomerMovieViewModel();
        //    customer cos = new customer { customerName = "Kanimozhi" };
        //    List<Movies> movies = new List<Movies>
        //    {
        //        new Movies{Name="BIGIL"},
        //        new Movies{Name="SARKAR"},
        //        new Movies{Name="MERSAL"},
        //        new Movies{Name="THERI"},
        //        new Movies{Name="MAARI"},

        //    };
        //    MovieDetail.Customers = cos;
        //    MovieDetail.Movie = movies;
        //    return View(MovieDetail);
        //}
        public ActionResult Details(int id)
        {
            var Movie1 = dbContext.movies.Include(c => c.Genre).ToList().SingleOrDefault(a => a.Id == id);
            return View(Movie1);

        }
        //public List<Movies> GetMovies()
        //{
        //    List<Movies> movies = new List<Movies>
        //    {
        //        new Movies{Id=1,MovieName="BIGIL",ActorName="Vijay",DirectorName="Atlee",ReleaseDate=Convert.ToDateTime("27/10/2019")},
        //         new Movies{Id=2,MovieName="NAMA VEETU PILLAI",ActorName="Sivakarthikeyan",DirectorName="Pandiraj",ReleaseDate=Convert.ToDateTime("27/09/2019")},
        //         new Movies{Id=3,MovieName="SARKAR",ActorName="Vijay",DirectorName="A.R.Murugadoss",ReleaseDate=Convert.ToDateTime("05/11/2018")},
        //          new Movies{Id=4,MovieName="MAARI",ActorName="Dhanush",DirectorName="Balaji Mohan",ReleaseDate=Convert.ToDateTime("27/12/2018")},


        //    };
        //    return movies;
        //}
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var movies = new Movies();
            ViewBag.GenreId = ListOfGnere();
            return View(movies);
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditMovies(int Id)
        {
            var movies = dbContext.movies.SingleOrDefault(c => c.Id == Id);
            if (movies != null)
            {
                ViewBag.GenreId = ListOfGnere();
                return View(movies);
            }
            return HttpNotFound("Movies id not exists");
        }
        [HttpPost]
        public ActionResult Create(Movies MoviesFromView)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.GenreId = ListOfGnere();
                return View(MoviesFromView);

            }
            dbContext.movies.Add(MoviesFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        [HttpPost]
        public ActionResult EditMovies(Movies MoviesFromView)
        {
            if (ModelState.IsValid)
            {
                var MoviesDb = dbContext.movies.FirstOrDefault(c => c.Id == MoviesFromView.Id);
                MoviesDb.MovieName = MoviesFromView.MovieName;
                MoviesDb.ActorName = MoviesFromView.ActorName;
                MoviesDb.AvailableStocks = MoviesFromView.AvailableStocks;
                MoviesDb.ReleaseDate = MoviesFromView.ReleaseDate;
                MoviesDb.Genre = MoviesFromView.Genre;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movie");
            }
            else
            {
                ViewBag.GenreId = ListOfGnere();
                return View(MoviesFromView);
            }

        }
        [Authorize]
        [HttpGet]
        public ActionResult DeleteMovies(int Id)
        {
            var movies = dbContext.movies.SingleOrDefault(c => c.Id == Id);
          
                ViewBag.GenreId = ListOfGnere();
                dbContext.movies.Remove(movies);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movie");
              
        }
       
            public IEnumerable<SelectListItem> ListOfGnere()
        {
            var gnere = dbContext.Genres.AsEnumerable().Select
                (c => new SelectListItem() { Text = c.GenereName, Value = c.Id.ToString() })
                .ToList();
            gnere.Insert(0, new SelectListItem { Text = "--select--", Value = "select", Disabled = true, Selected = true });
            return gnere;
        }
    }
}