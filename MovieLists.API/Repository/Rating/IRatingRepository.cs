using MovieLists.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Repository
{
    public interface IRatingRepository
    {
        #region PUT Methods
        Task<RatingDTO> Update(RatingDTO rating, UserDTO user);
        #endregion PUT Methods

        #region POST Methods
        Task<RatingDTO> Insert(RatingDTO rating, UserDTO user);
        #endregion POST Methods
    }
}
