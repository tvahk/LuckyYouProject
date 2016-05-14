using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DrawDurationService
    {
        private DAL.Interfaces.IDrawDurationRepository _repo;
        private Factories.DrawDurationFactory _factory;

        public DrawDurationService()
        {
            this._repo = new DAL.Repositories.DrawDurationRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.DrawDurationFactory();
        }

        public List<DTO.DrawDurationDTO> getAllDrawDurations()
        {
            return
               this._repo.All.Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.DrawDurationDTO getDrawDurationById(int id)
        {
           var query = _repo.All.Where(x => _factory.createBasicDTO(x).DrawDurationId == id).FirstOrDefault();
            return new DTO.DrawDurationDTO()
            {
                DrawDurationId = query.DrawDurationId,
                DrawDurationValue = query.DrawDurationValue,
                DrawDurationPrice = query.DrawDurationPrice
            };
        }
    }
}
