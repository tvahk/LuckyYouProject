using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DrawPriorityService
    {
        private DAL.Interfaces.IDrawPriorityRepository _repo;
        private Factories.DrawPriorityFactory _factory;

        public DrawPriorityService()
        {
            this._repo = new DAL.Repositories.DrawPriorityRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.DrawPriorityFactory();
        }

        public List<DTO.DrawPriorityDTO> getAllDrawPriorities()
        {
            return
               this._repo.All.Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.DrawPriorityDTO getDrawPrioritylById(int id)
        {
            var query = _repo.All.Where(x => _factory.createBasicDTO(x).DrawPriorityId == id).FirstOrDefault();
            return new DTO.DrawPriorityDTO()
            {
                DrawPriorityId = query.DrawPriorityId,
                DrawPriorityValue = query.DrawPriorityValue,
                DrawPriorityPrice = query.DrawPriorityPrice
            };
        }
    }
}
