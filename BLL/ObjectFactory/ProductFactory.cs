using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class ProductFactory
    {
        public DTO.ProductDTO createBasicDTO(Domain.Product product)
        {
            return new DTO.ProductDTO()
            {
                ProductId = product.ProductId,
                ProductValue = product.ProductValue,
                FirstLastName = product.User.FirstLastName,
                ProductType = product.ProductType.ProductTypeValue
            };
        }
    }
}