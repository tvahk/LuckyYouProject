using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductService
    {
        private DAL.Interfaces.IProductRepository _repo;
        private Factories.ProductFactory _factory;

        public ProductService()
        {
            this._repo = new DAL.Repositories.ProductRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.ProductFactory();
        }

        public List<DTO.ProductDTO> getAllProducts()
        {
            return
               this._repo.getAllProductsIncludeOthers().Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.ProductDTO getProductById(int id)
        {
            var query = _repo.getAllProductsIncludeOthers().Where(x => _factory.createBasicDTO(x).ProductId == id).FirstOrDefault();
            return new DTO.ProductDTO()
            {
                ProductId = query.ProductId,
                ProductValue = query.ProductValue,
                FirstLastName = query.User.FirstLastName,
                ProductType = query.ProductType.ProductTypeValue
            };
        }
    }
}
