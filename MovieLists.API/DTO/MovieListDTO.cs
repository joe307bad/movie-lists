using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.DTO
{
    public class MovieListDTO : BaseDTO
    {
        public string Name { get; set; }
        public UserDTO User { get; set; }
        public List<MovieDTO> Movies { get; set; }
        public int NumOfMovies { get; set; }
        public double AverageRating { get; set; }

        public MovieListDTO()
        {
            Movies = new List<MovieDTO>();
            User = new UserDTO();
        }

        public static MovieListDTO Populate(MovieList movieList)
        {
            var userRatings = new List<Rating>();
            if(movieList.User != null && movieList.Movies != null)
            {
                userRatings = movieList.Movies
                    .Select(_ => _.Ratings.FirstOrDefault(r => r.User.Id == movieList.User.Id)).ToList();
            }

            var movieListMovies = new List<MovieDTO>();
            if(movieList.Movies != null)
            {
                movieListMovies = movieList.Movies.Select(_ => MovieDTO.Populate(_)).Select(_ =>
                {
                    var userRating = new Rating();
                    if (userRatings.Any())
                        userRating = userRatings.FirstOrDefault(ur => ur.Movie.Id == _.Id);
                    if (userRating != null)
                        _.UserRating = RatingDTO.Populate(userRating);
                    return _;
                }).ToList();
            }

            double averageRating = 0;
            var moviesToAverage = movieListMovies.Where(_ => _.UserRating.Score != Score.UNRATED);
            if (moviesToAverage.Any())
            {
                averageRating = moviesToAverage.Average(_ => (int)_.UserRating.Score);
            }

                return new MovieListDTO
            {
                Id = movieList.Id,
                Name = movieList.Name,
                Movies = movieListMovies,
                NumOfMovies = movieListMovies.Count(),
                AverageRating = averageRating
                };
        }
    }
}
