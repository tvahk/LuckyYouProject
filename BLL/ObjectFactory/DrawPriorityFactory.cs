using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class DrawPriorityFactory
    {
        public DTO.DrawPriorityDTO createBasicDTO(Domain.DrawPriority drawPriority)
        {
            return new DTO.DrawPriorityDTO
            {
                DrawPriorityId = drawPriority.DrawPriorityId,
                DrawPriorityValue = drawPriority.DrawPriorityValue,
                DrawPriorityPrice = drawPriority.DrawPriorityPrice
            };
        }
    }
}
