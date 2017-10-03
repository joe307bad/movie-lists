using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.DTO
{
    public class RatingDTO : BaseDTO
    {
        public DB.Score Score { get; set; }
        public UserDTO User { get; set; }
        public MovieDTO Movie { get; set; }

        public static RatingDTO Populate(Rating rating)
        {
            return new RatingDTO
            {
                Score = rating.Score,
                User = rating.User != null ? UserDTO.Populate(rating.User) : new UserDTO(),
                Movie = rating.Movie != null ? MovieDTO.Populate(rating.Movie) : new MovieDTO()
            };
        }
    }
    
}
