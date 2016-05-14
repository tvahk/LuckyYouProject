using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class DrawSizeFactory
    {
        public DTO.DrawSizeDTO createBasicDTO(Domain.DrawSize drawSize)
        {
            return new DTO.DrawSizeDTO()
            {
                DrawSizeId = drawSize.DrawSizeId,
                DrawSizeValue = drawSize.DrawSizeValue,
                DrawSizePrice = drawSize.DrawSizePrice
            };
        }
    }
}