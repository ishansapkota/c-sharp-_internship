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
            TempData["AlertMessage"] = "Movie Added to the Database Successfully";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movie = await applicationDbContext.Movies.ToListAsync();
          
            return View("MovieList",movie);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var movie =await applicationDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie != null)
            {
                var ViewModel = new UpdateMoviesViewModel()
                {
                    Id = movie.Id,
                    MovieName = movie.MovieName,
                    Genre = movie.Genre,
                    ReleaseDate = movie.ReleaseDate,
                    Actors = movie.Actors
                };
                return await Task.Run(()=>View("Update",ViewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMoviesViewModel updatemovies)
        {
            var movie = await applicationDbContext.Movies.FindAsync(updatemovies.Id);
            if (movie != null) {
                movie.Id = updatemovies.Id;
                movie.MovieName = updatemovies.MovieName;
                movie.Genre = updatemovies.Genre;
                movie.ReleaseDate = updatemovies.ReleaseDate;
                movie.Actors = updatemovies.Actors;

                await applicationDbContext.SaveChangesAsync();
                TempData["AlertMessage"] = "Movie Updated to the Database Successfully";
                return RedirectToAction("Index");
                }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(UpdateMoviesViewModel updateMovies)
        {
            var movie = await applicationDbContext.Movies.FindAsync(updateMovies.Id);
            if(movie != null)
            {
                applicationDbContext.Movies.Remove(movie);
                await applicationDbContext.SaveChangesAsync();
                TempData["DangerMessage"] = "Movie has been deleted from the Database";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
