using MovieLists.API.DTO;
using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly Context _context;

        public RatingRepository(Context ctx)
        {
            _context = ctx;
        }
        
        public async Task<RatingDTO> Insert(RatingDTO rating, UserDTO user)
        {
            var ratedMovie = _context.Movies.FirstOrDefault(_ => _.ImdbId == rating.Movie.ImdbId);
            var ratingUser = _context.Users.FirstOrDefault(_ => _.Name == user.Name);

            if (ratedMovie == null)
            {
                ratedMovie = new Movie
                {
                    ImdbId = rating.Movie.ImdbId,
                    PosterUrl = rating.Movie.PosterUrl,
                    Release = rating.Movie.Release,
                    Title = rating.Movie.Title
                };
                _context.Movies.Add(ratedMovie);
                await _context.SaveChangesAsync();
            }

            if (ratingUser == null)
            {
                ratingUser = new User
                {
                    Name = user.Name
                };
                _context.Users.Add(ratingUser);
                await _context.SaveChangesAsync();
            }

            var newRating = new Rating
            {
                Movie = ratedMovie,
                Score = rating.Score,
                User = ratingUser
            };
            _context.Ratings.Add(newRating);
            await _context.SaveChangesAsync();

            return RatingDTO.Populate(newRating);
        }

        public async Task<RatingDTO> Update(RatingDTO rating, UserDTO user)
        {
            var updateRating = _context.Ratings.FirstOrDefault(_ => _.Id == rating.Id);
            updateRating.Score = updateRating.Score;

            _context.Ratings.Update(updateRating);
            await _context.SaveChangesAsync();

            return RatingDTO.Populate(updateRating);
        }
        
    }

}
