using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class ProductTypeFactory
    {
        public DTO.ProductTypeDTO createBasicDTO(Domain.ProductType productType)
        {
            return new DTO.ProductTypeDTO()
            {
                ProductTypeId = productType.ProductTypeId,
                ProductTypeValue = productType.ProductTypeValue,
                Products = productType.Products
            };
        }
    }
}