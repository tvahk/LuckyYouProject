using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class WinningFactory
    {
        public DTO.WinningDTO createBasicDTO(Domain.Winning winning)
        {
            return new DTO.WinningDTO()
            {
                WinningId = winning.WinningId,
                WinningDate = winning.WinningDate,
                WinningComment = winning.WinningComment,
                DrawName = winning.Draw.DrawName,
                FirstLastName = winning.User.FirstLastName
            };
        }
    }
}
