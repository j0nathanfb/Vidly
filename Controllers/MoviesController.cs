using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }


        private readonly ApplicationDbContext _context;

        public ActionResult New()
        {
            var genres = _context.Genres;

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.Genre = _context.Genres.Single(g => g.Id == movie.GenreId);
                _context.Movies.Add(movie);
            }
            else
            {
                var movieFromDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieFromDb.Name = movie.Name;
                movieFromDb.GenreId = movie.GenreId;
                movieFromDb.ReleaseDate = movie.ReleaseDate;
                movieFromDb.StockCount = movie.StockCount;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie is null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres
            };

            return View("MovieForm", viewModel);
        }
    }
}