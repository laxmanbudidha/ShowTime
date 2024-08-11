using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Models.Response.Movie;
using Data_Access_Layer.MovieRepository;


namespace Business_Logic_Layer.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IMovieRepository movieRepository, ILogger<MovieService> logger)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _logger = logger;
        }

       
        public Movie GetMovieById(int Id)
        {
            try
            {
                return _movieRepository.GetMovieById(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting movie with ID {Id}", Id);
                throw new Exception("An error occurred while retrieving the movie.");
            }
        }
       
        public async Task<IEnumerable<Movie>> GetAllMovies(string UserName)
        {
            
            try
            {
                return await _movieRepository.GetAllMovies(UserName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting movie");
                throw new Exception("An error occurred while retrieving the movie.");
            }
        }


        public int InsertMovie(Movie movie)
        {
            try
            {
                return _movieRepository.InsertMovie(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting a new movie.");
                throw new Exception("An error occurred while inserting the movie.");
            }
        }

        public void UpdateMovie(Movie movie)
        {
            try
            {
                _movieRepository.UpdateMovie(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the movie with ID {Id}", movie.Id);
                throw new Exception("An error occurred while updating the movie.");
            }
        }

        public void DeleteMovie(int id, string UserName)
        {
            try
            {
                _movieRepository.DeleteMovie(id, UserName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the movie with ID {Id}", id);
                throw new Exception("An error occurred while deleting the movie.");
            }
        }


    }
}
