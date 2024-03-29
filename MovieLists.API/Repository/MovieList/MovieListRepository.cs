﻿using Microsoft.EntityFrameworkCore;
using MovieLists.API.DTO;
using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Repository
{
    public class MovieListRepository : IMovieListRepository
    {
        private readonly Context _context;

        public MovieListRepository(Context ctx)
        {
            _context = ctx;
        }

        public Guid Delete(Guid id)
        {
            var deleteMovieList = _context.MovieLists.FirstOrDefault(_ => _.Id == id);
            if (deleteMovieList != null)
                _context.MovieLists.Remove(deleteMovieList);

            return deleteMovieList != null ? deleteMovieList.Id : Guid.Empty;
        }

        public MovieListDTO Get(Guid id)
        {
            var movieList = _context.MovieLists.FirstOrDefault(_ => _.Id == id);
            return MovieListDTO.Populate(movieList) ?? new MovieListDTO();
        }

        public List<MovieListDTO> GetAll()
        {
            var movieLists = _context.MovieLists.ToList();
            return movieLists.Select(_ => MovieListDTO.Populate(_)).ToList() ?? new List<MovieListDTO>();
        }

        public async Task<MovieListDTO> Insert(MovieListDTO movieList)
        {
            var newMovieList = new MovieList
            {
                Name = movieList.Name,
                User = new User
                {
                    Id = movieList.User.Id,
                    Name = movieList.User.Name,
                }
            };
            _context.MovieLists.Add(newMovieList);
            await _context.SaveChangesAsync();

            return MovieListDTO.Populate(newMovieList);
        }

        public async Task<MovieListDTO> Update(MovieListDTO movieList)
        {
            var updateMovieList = _context.MovieLists.FirstOrDefault(_ => _.Id == movieList.Id);
            updateMovieList.Name = movieList.Name;

            _context.MovieLists.Update(updateMovieList);
            await _context.SaveChangesAsync();

            return MovieListDTO.Populate(updateMovieList);
        }

        public async Task<MovieListDTO> AddMovie(MovieListDTO movieList, MovieDTO movie)
        {
            var updateMovieList = _context.MovieLists.Include("Movies").FirstOrDefault(_ => _.Id == movieList.Id);

            var movieAlreadyAdded = false;
            if (updateMovieList.Movies != null)
                movieAlreadyAdded = updateMovieList.Movies.Any(_ => _.ImdbId == movie.ImdbId);

            if (!movieAlreadyAdded)
            {
                var addMovie = new Movie
                {
                    ImdbId = movie.ImdbId,
                    PosterUrl = movie.PosterUrl,
                    Release = movie.Release,
                    Title = movie.Title
                };
                _context.Movies.Add(addMovie);
                await _context.SaveChangesAsync();

                if (updateMovieList.Movies == null)
                    updateMovieList.Movies = new List<Movie>();

                updateMovieList.Movies.Add(addMovie);
                _context.MovieLists.Update(updateMovieList);

                await _context.SaveChangesAsync();
            }

            return MovieListDTO.Populate(updateMovieList);
        }

        public async Task<MovieListDTO> RemoveMovie(MovieListDTO movieList, MovieDTO movie)
        {
            var updateMovieList = _context.MovieLists.Include("Movies").FirstOrDefault(_ => _.Id == movieList.Id);
            if (updateMovieList.Movies != null)
            {
                var removeMovie = updateMovieList.Movies.FirstOrDefault(_ => _.ImdbId == movie.ImdbId);

                if (removeMovie != null)
                {
                    updateMovieList.Movies.Remove(removeMovie);
                    _context.MovieLists.Update(updateMovieList);
                    await _context.SaveChangesAsync();
                }
            }

            return MovieListDTO.Populate(updateMovieList);
        }
    }

}
