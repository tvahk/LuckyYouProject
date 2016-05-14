using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class DrawCategoryFactory
    {
        public DTO.DrawCategoryDTO createBasicDTO(Domain.DrawCategory drawCategory)
        {
            return new DTO.DrawCategoryDTO()
            {
                DrawCategoryId = drawCategory.DrawCategoryId,
                DrawCategoryValue = drawCategory.DrawCategoryValue,
            };
        }
    }
}