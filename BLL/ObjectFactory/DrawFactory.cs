using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Service;

namespace BLL.Factories
{
    public class DrawFactory
    {
        public DTO.DrawDTO createBasicDTO(Domain.Draw draw)
        {

            return new DTO.DrawDTO()
            {
                DrawId = draw.DrawId,
                DrawProductsAmount = draw.DrawProductsAmount,
                AgeGroup = draw.AgeGroup,
                DrawName = draw.DrawName,
                DrawStartDate = draw.DrawStartDate,
                DrawFacebookAddress = draw.DrawFaceBookAddress,
                // Display End Date
                DrawEndDate = draw.DrawStartDate.AddHours(draw.DrawDuration.DrawDurationValue),
                ProductName = draw.Product.ProductValue,
                DrawCategory = draw.DrawCategory.DrawCategoryValue,
                FirstName = draw.User.FirstName,
                DrawDuration = draw.DrawDuration.DrawDurationValue,
                DrawSize = draw.DrawSize.DrawSizeValue,
                DrawPriority = draw.DrawPriority.DrawPriorityValue,
            };
        }

       
    }
}
