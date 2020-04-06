using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public VidlyDBContext _context;

        public MoviesController()
        {
            _context = new VidlyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>()
            {
                new Customer() {Name= "customer1"},
                new Customer() {Name="customer2"}
            };

            var vm = new RandomMovieVm()
            {
                Movie = movie,
                Customers = customers
            };

            return View(vm);
            //return View(movie);
            //return Content("hello world");
            //return RedirectToAction("Index", "Home");
            //return HttpNotFound();
        }

        // GET: Movies?pageindex=1&sortby=size
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var moviesVm = new MoviesVm() { Movies = movies };
            return View(moviesVm);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("{0}/{1}", month, year));
        }
    }
}