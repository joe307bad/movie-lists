using MovieLists.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Repository
{
    public interface IOmdbRepository
    {
        #region GET Methods
        Task<List<MovieDTO>> Search(OmdbSearchRequestDTO searchRequest);
        Task<MovieDTO> GetOne(MovieDTO movie, UserDTO user);
        #endregion GET Methods
    }
}
