using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyMoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesData _data;

        public MovieController(MoviesData data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return Ok(await _data.Movies.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> Get(int id)
        {
            var movie = await _data.Movies.FindAsync(id);
            if (movie == null)
                return BadRequest("Movie not found.");
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            _data.Movies.Add(movie);
            await _data.SaveChangesAsync();
            return Ok(await _data.Movies.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie request)
        {
            var dbMovies = await _data.Movies.FindAsync(request.Id);
            if (dbMovies == null)
                return BadRequest("Movie not found.");

            dbMovies.Title = request.Title;
            dbMovies.Year = request.Year;

            await _data.SaveChangesAsync();

            return Ok(await _data.Movies.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> Delete(int id)
        {
            var dbMovies = await _data.Movies.FindAsync(id);
            if (dbMovies == null)
                return BadRequest("Movie not found.");

            _data.Movies.Remove(dbMovies);
            await _data.SaveChangesAsync();

            return Ok(await _data.Movies.ToListAsync());
        }
    }
}
