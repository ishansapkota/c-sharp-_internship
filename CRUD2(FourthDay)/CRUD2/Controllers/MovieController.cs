using CRUD2.Data;
using CRUD2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD2.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MovieController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
          public IActionResult Add()
        {
            return View("AddMovie");
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddMovieViewModel addMovie)
        {
            var movie = new Movies
            {
                MovieName = addMovie.movieName,
                Genre = addMovie.genre,
                ReleaseDate = addMovie.releaseDate,
                Actors = addMovie.actors

            };
            await applicationDbContext.Movies.AddAsync(movie);
            await applicationDbContext.SaveChangesAsync();
            return RedirectToAction("AddMovie");

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movie = await applicationDbContext.Movies.ToListAsync();
          
            return View(movie);

        }
    }
}
