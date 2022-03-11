using Microsoft.EntityFrameworkCore;

namespace MyMoviesAPI.Data
{
    public class MoviesData : DbContext
    {
        public MoviesData(DbContextOptions<MoviesData> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
