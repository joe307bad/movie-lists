using Microsoft.AspNetCore.Mvc;
using MovieLists.API.DTO;
using MovieLists.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLists.API.Controllers
{
    public class MovieListsController : Controller
    {
        private IMovieListRepository _movieListRepository;

        public MovieListsController(IMovieListRepository movieListRepository) => _movieListRepository = movieListRepository;
        
        [HttpPost]
        public async Task<IActionResult> Index([FromBody]MovieListDTO movieList)
        {
            try
            {
                var newMovieList = await _movieListRepository.Insert(movieList);
                return Ok(newMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var movieLists = _movieListRepository.GetAll();
                return Ok(movieLists);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpGet]
        public IActionResult Index(Guid id)
        {
            try
            {
                var movieList = _movieListRepository.Get(id);
                return Ok(movieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpDelete, Route("[action]/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var deletedMovieList = _movieListRepository.Delete(id);
                return Ok(deletedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpPut, Route("[action]/{id}")]
        public IActionResult Edit(Guid id)
        {
            try
            {
                var editedMovieList = _movieListRepository.Update(id);
                return Ok(editedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpPut, Route("[action]/{id}")]
        public IActionResult AddMovie(MovieListDTO movieList, MovieDTO movie)
        {
            try
            {
                var editedMovieList = _movieListRepository.AddMovie(movieList, movie);
                return Ok(editedMovieList);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

    }
}
