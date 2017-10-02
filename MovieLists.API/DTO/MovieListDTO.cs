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
            var userRatings = movieList.Movies.Select(_ => _.Ratings.FirstOrDefault(r => r.User.Id == movieList.User.Id));
            var movieListMovies = movieList.Movies.Select(_ => MovieDTO.Populate(_)).Select(_ =>
            {
                var userRating = userRatings.FirstOrDefault(ur => ur.Movie.Id == _.Id);
                if (userRating != null)
                    _.UserRating = RatingDTO.Populate(userRating);
                return _;
            });
            return new MovieListDTO
            {
                Id = movieList.Id,
                Name = movieList.Name,
                Movies = movieListMovies.ToList(),
                NumOfMovies = movieList.Movies.Count(),
                AverageRating = movieListMovies
                                    .Where(_ => _.UserRating.Score != Score.UNRATED).Average(_ => (int)_.UserRating.Score)
            };
        }
    }
}
