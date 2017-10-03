using MovieLists.API.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieLists.API.DTO;
using MovieLists.API.Helpers;
using MovieLists.DB;

namespace MovieLists.API.Repository
{
    public class OmdbRepository : IOmdbRepository
    {
        private static Uri uri = new Uri("http://www.omdbapi.com");
        private readonly Context _context;

        public OmdbRepository(Context ctx)
        {
            _context = ctx;
        }

        public async Task<List<MovieDTO>> Search(OmdbSearchRequestDTO searchRequest)
        {
            var queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("s", searchRequest.SearchQuery);
            queryDictionary.Add("apiKey", "2f3362ff");
            var queryString = queryDictionary.ToQueryString();

            var endpoint = OmdbEndpoints.SEARCH_MOVIES.DescriptionAttr() + queryString;
            var ombdResults = await ApiRequest.Make(uri, endpoint);

            var movieResults = ombdResults.OmdbResultToApiResult();
            var movieResultIds = movieResults.Select(_ => _.ImdbId);

            var ratings = _context.Ratings;
            var movieRatings = new List<Rating>();
            if(ratings.Any())
                movieRatings = _context.Ratings.Where(_ => movieResultIds.Any(mrid => mrid == _.Movie.ImdbId)).ToList();

            if (movieRatings.Any())
            {
                movieResults.Select(_ => {
                    var rating = movieRatings.FirstOrDefault(mr => mr.Movie.ImdbId == _.ImdbId);
                    _.UserRating = RatingDTO.Populate(rating);
                    return _;
                });
            }

            return movieResults;
        }

        public async Task<MovieDTO> GetOne(MovieDTO movie, UserDTO user)
        {
            var queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("i", movie.ImdbId);
            queryDictionary.Add("apiKey", "2f3362ff");
            var queryString = queryDictionary.ToQueryString();

            var endpoint = OmdbEndpoints.GET_ONE_MOVIE.DescriptionAttr() + queryString;

            var ombdResult = await ApiRequest.Make(uri, endpoint);
            var movieResult = ombdResult.OmdbResultToMovieDTO();

            var movieRating = _context.Ratings.FirstOrDefault(_ => _.Movie.ImdbId == movie.ImdbId && _.User.Id == user.Id);

            if(movieRating != null)
            {
                movieResult.UserRating = RatingDTO.Populate(movieRating);
            }
            else
            {
                movieResult.UserRating = new RatingDTO
                {
                    Score = DB.Score.UNRATED
                };
            }

            return movieResult;
        }
    }

    public enum OmdbEndpoints
    {
        [Description("/")]
        SEARCH_MOVIES,
        [Description("/")]
        GET_ONE_MOVIE
    }
}
