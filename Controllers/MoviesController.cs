using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View(_movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _movies.SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        private readonly List<Movie> _movies = new List<Movie> { new Movie { Id = 1, Name = "Star Wars" }, new Movie { Id = 2, Name = "Close Encounters" } };

    }
}