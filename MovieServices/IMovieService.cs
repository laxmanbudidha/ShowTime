using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Models.Response.Movie;

namespace Business_Logic_Layer.MovieServices
{
    public interface IMovieService
    {
        Movie GetMovieById(int Id);
        Task<IEnumerable<Movie>> GetAllMovies(string UserName);
        int InsertMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id, string UserName);
    }
}
