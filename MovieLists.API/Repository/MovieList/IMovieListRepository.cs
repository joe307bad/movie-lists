using MovieLists.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Repository
{
    public interface IMovieListRepository
    {
        #region GET Methods
        MovieListDTO Get(Guid id);
        List<MovieListDTO> GetAll();
        #endregion GET Methods

        #region PUT Methods
        Task<MovieListDTO> Update(MovieListDTO movieList);
        Task<MovieListDTO> AddMovie(MovieListDTO movieList, MovieDTO movie);
        #endregion PUT Methods

        #region POST Methods
        Task<MovieListDTO> Insert(MovieListDTO movieList);
        #endregion POST Methods

        #region DELETE Methods
        Guid Delete(Guid id);
        #endregion DELETE Methods
    }
}
