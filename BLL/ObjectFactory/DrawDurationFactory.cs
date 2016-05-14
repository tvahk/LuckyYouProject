using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class DrawDurationFactory
    {
        public DTO.DrawDurationDTO createBasicDTO(Domain.DrawDuration drawDuration)
        {
            return new DTO.DrawDurationDTO()
            {
                DrawDurationId = drawDuration.DrawDurationId,
                DrawDurationValue = drawDuration.DrawDurationValue,
                DrawDurationPrice = drawDuration.DrawDurationPrice
            };
        }
    }
}