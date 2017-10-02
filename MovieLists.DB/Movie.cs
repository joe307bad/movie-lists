using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLists.DB
{
    public class Movie : BaseEntity
    {
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public string PosterUrl { get; set; }
        public Genre Genre { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
