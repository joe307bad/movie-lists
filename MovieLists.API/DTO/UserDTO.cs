using MovieLists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.DTO
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }

        public static UserDTO Populate(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
