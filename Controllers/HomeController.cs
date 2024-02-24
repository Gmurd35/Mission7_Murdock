using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Murdock.Models;
using System.Diagnostics;

namespace Mission6_Murdock.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;
        public HomeController(MovieContext temp) 
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.CategoryVar = _context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Form(Movie response) 
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation");
        }

        public IActionResult MoviesList()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.CategoryVar = _context.Categories.ToList();

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie info)
        {
            _context.Update(info);
            _context.SaveChanges();

            return RedirectToAction("MoviesList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("MoviesList");
        }
    }
}
