using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.DTO
{
    public class OmdbResultDTO
    {
        public string totalResults { get; set; }
        public List<OmdbItemDTO> Search { get; set; }
    }

    public class OmdbItemDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string ImdbId { get; set; }
        public string Poster { get; set; }
    }

    public class OmdbDetailedItemDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string ImdbId { get; set; }
        public string Poster { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Plot { get; set; }
    }

    public class OmdbSearchRequestDTO
    {
        public string SearchQuery { get; set; }
        public string Page { get; set; }
        public string Type { get; set; }
    }
}
