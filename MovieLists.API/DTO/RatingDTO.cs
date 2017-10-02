using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.DTO
{
    public class RatingDTO : BaseDTO
    {
        public Score Score { get; set; }
        public UserDTO User { get; set; }
        public MovieDTO Movie { get; set; }

        public static RatingDTO Populate(Rating rating)
        {
            return new RatingDTO
            {
                Score = rating.Score,
                User = rating.User,
                Movie = rating.Movie
            };
        }
    }

    public enum Score
    {
        UNRATED,
        ZERO_STARS,
        ONE_STAR,
        TWO_STARS,
        THREE_STARS,
        FOUR_STARS,
        FIVE_STARS
    }
}
