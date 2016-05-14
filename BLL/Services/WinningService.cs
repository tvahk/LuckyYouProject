using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class WinningService
    {
        private DAL.Interfaces.IWinningRepository _repo;
        private Factories.WinningFactory _factory;

        public WinningService()
        {
            this._repo = new DAL.Repositories.WinningRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.WinningFactory();
        }

        public List<DTO.WinningDTO> getAllWinnings()
        {
            return
                this._repo.GetAllWinningsWithUserAndDraws().Select(
                    x => _factory.createBasicDTO(x)).ToList();
        }

        public int CountUserWinnings(string userId)
        {
            var query = _repo.CountUserWinnings(userId);
            return query;
        }

        public DTO.WinningDTO getWinningById(int id)
        {
            var query = _repo.GetAllWinningsWithUserAndDraws().Where(x => _factory.createBasicDTO(x).WinningId == id).FirstOrDefault();
            return new DTO.WinningDTO()
            {
                WinningId = query.WinningId,
                WinningDate = query.WinningDate,
                WinningComment = query.WinningComment,
                DrawName = query.Draw.DrawName,
                FirstLastName = query.User.FirstLastName
            };
        }
    }
}
