using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLists.DB
{
    public class MovieList : BaseEntity
    {
        public string Name { get; set; }
        public User User { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
