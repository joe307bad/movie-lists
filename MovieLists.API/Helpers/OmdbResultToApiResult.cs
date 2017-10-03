using MovieLists.API.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Helpers
{
    /// <summary>
    /// Interface between Omdb API and MovieLists API
    /// </summary>
    public static class OmdbToAPI
    {
        public static List<MovieDTO> OmdbResultToApiResult(this string omdbResult)
        {
            var omdbResultParsed = JsonConvert.DeserializeObject<OmdbResultDTO>(omdbResult);
            return omdbResultParsed.Search.Select(_ => new MovieDTO
            {
                ImdbId = _.ImdbId,
                Release = new DateTime(_.Year, 1, 1),
                Title = _.Title,
                PosterUrl = _.Poster
            }).ToList();
        }

        public static MovieDTO OmdbResultToMovieDTO(this string omdbResult)
        {
            var omdbResultParsed = JsonConvert.DeserializeObject<OmdbDetailedItemDTO>(omdbResult);
            return new MovieDTO
            {
                ImdbId = omdbResultParsed.ImdbId,
                Release = DateTime.ParseExact(omdbResultParsed.Released, "dd MMM yyyy", CultureInfo.InvariantCulture),
                Title = omdbResultParsed.Title,
                PosterUrl = omdbResultParsed.Poster
            };
        }
    }
}
