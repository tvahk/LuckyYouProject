using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DomainLogic.IdentityModels;

namespace BLL.Factories
{
    public class UserFactory
    {
        public DTO.UserDTO createBasicDTO(User user)
        {
            return new DTO.UserDTO
            {
                UserId = user.Id,
                UserName = user.UserName,
                //UserAccountPassword = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Score = user.Score
                //UserTypeId = user.UserTypeId
            };
        }
    }
}
