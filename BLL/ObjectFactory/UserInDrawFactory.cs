using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class UserInDrawFactory
    {
        public DTO.UserInDrawDTO createBasicDTO(Domain.UserInDraw userInDraw)
        {
            return new DTO.UserInDrawDTO
            {
                UserInDrawId = userInDraw.UserInDrawId,
                UserInDrawDate = userInDraw.UserInDrawDate,
                FirstLastName = userInDraw.User.FirstLastName,
                DrawName = userInDraw.Draw.DrawName
            };
        }
    }
}