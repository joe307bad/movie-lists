using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.DTO
{
    public class MovieDTO : BaseDTO
    {
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public string PosterUrl { get; set; }
        public RatingDTO UserRating { get; set; }
        public int AverageOverallRating { get; set; }

        public static MovieDTO Populate(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id,
                ImdbId = movie.ImdbId,
                PosterUrl = movie.PosterUrl,
                Release = movie.Release,
                Title = movie.Title
            };
        }
    }
}
