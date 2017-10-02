using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLists.DB
{
    public class MovieList : BaseEntity
    {
        public string Name;
        public User User;
        public List<Movie> Movies;
    }
}
