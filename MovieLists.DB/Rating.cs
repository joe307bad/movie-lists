using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLists.DB
{
    public class Rating : BaseEntity
    {
        public Score Score { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
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
