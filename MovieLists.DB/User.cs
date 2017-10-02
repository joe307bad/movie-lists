using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLists.DB
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public List<MovieList> MovieLists { get; set; }
    }
}
