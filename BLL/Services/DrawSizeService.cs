using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DrawSizeService
    {
        private DAL.Interfaces.IDrawSizeRepository _repo;
        private Factories.DrawSizeFactory _factory;

        public DrawSizeService()
        {
            this._repo = new DAL.Repositories.DrawSizeRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.DrawSizeFactory();
        }

        public List<DTO.DrawSizeDTO> getAllDrawSizes()
        {
            return
               this._repo.All.Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.DrawSizeDTO getDrawSizeById(int id)
        {
            var query = _repo.All.Where(x => _factory.createBasicDTO(x).DrawSizeId == id).FirstOrDefault();
            return new DTO.DrawSizeDTO()
            {
                DrawSizeId = query.DrawSizeId,
                DrawSizeValue = query.DrawSizeValue,
                DrawSizePrice = query.DrawSizePrice
            };
        }
    }
}
