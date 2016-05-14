using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductTypeService
    {
        private DAL.Interfaces.IProductTypeRepository _repo;
        private Factories.ProductTypeFactory _factory;

        public ProductTypeService()
        {
            this._repo = new DAL.Repositories.ProductTypeRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.ProductTypeFactory();
        }

        public List<DTO.ProductTypeDTO> getAllProductTypes()
        {
            return
               this._repo.All.Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.ProductTypeDTO getProductTypeById(int id)
        {
            var query = _repo.All.Where(x => _factory.createBasicDTO(x).ProductTypeId == id).FirstOrDefault();
            return new DTO.ProductTypeDTO()
            {
                ProductTypeId = query.ProductTypeId,
                ProductTypeValue = query.ProductTypeValue,
                Products = query.Products
            };
        }
    }
}
