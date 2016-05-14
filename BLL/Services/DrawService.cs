using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DrawService
    {
        private DAL.Interfaces.IDrawRepository _drawRepository;
        private DAL.Interfaces.IDrawPriorityRepository _drawPriorityRepository;
        private DAL.Interfaces.IDrawSizeRepository _drawSizeRepository;
        private DAL.Interfaces.IDrawDurationRepository _drawDurationRepository;
        private Factories.DrawFactory _factory;

        public DrawService()
        {
            this._drawPriorityRepository = new DAL.Repositories.DrawPriorityRepository(new DAL.LuckyYouDbContext());
            this._drawSizeRepository = new DAL.Repositories.DrawSizeRepository(new DAL.LuckyYouDbContext());
            this._drawDurationRepository = new DAL.Repositories.DrawDurationRepository(new DAL.LuckyYouDbContext());
            this._drawRepository = new DAL.Repositories.DrawRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.DrawFactory();
        }

        public int GenerateBillFromDraws(int drawDurationId, int drawSizeId, int drawPriorityId)
        {
            int drawPriority = _drawPriorityRepository.GetDrawPriorityPrice(drawPriorityId).DrawPriorityPrice;
            int drawSize = _drawSizeRepository.GetDrawSizePrice(drawSizeId).DrawSizePrice;
            int drawDuration = _drawDurationRepository.GetDrawDurationPrice(drawDurationId).DrawDurationPrice;

            return drawDuration + drawSize + drawPriority;
        }

        public List<DTO.DrawDTO> getAllDraws()
        {
               return
               this._drawRepository.GetAllDraws().Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

       

        public List<DTO.DrawDTO> getAllDrawsByUserId(string userid)
        {
            return
            this._drawRepository.GetAllDraws().Where(x => x.UserId == userid).Select(
                x => _factory.createBasicDTO(x)).ToList();
        }

        public List<DTO.DrawDTO> getAllDrawsByCategoryId(int categoryId)
        {
            return
                _drawRepository.GetAllDraws()
                    .Where(x => x.DrawCategoryId == categoryId)
                    .Select(y => _factory.createBasicDTO(y))
                    .ToList();
        }

        public List<DTO.DrawDTO> getAllDrawsByPriorityId(int priorityId)
        {
            return
                _drawRepository.GetDrawsByPriority(priorityId)
                    .Select(y => _factory.createBasicDTO(y))
                    .ToList();
        }
        public List<DTO.DrawDTO> getDrawsByDurationId(int drawDurationId)
        {
            return
               _drawRepository.GetAllDraws()
                   .Where(x => x.DrawDurationId == drawDurationId)
                   .Select(y => _factory.createBasicDTO(y))
                   .ToList();
        }

        public DTO.DrawDTO getDrawById(int id)
        {
            var query = _drawRepository.GetAllDraws().Where(x => _factory.createBasicDTO(x).DrawId == id).FirstOrDefault();
            return new DTO.DrawDTO()
            {
                DrawId = query.DrawId,
                DrawProductsAmount = query.DrawProductsAmount,
                AgeGroup = query.AgeGroup,
                DrawStartDate = query.DrawStartDate,
                DrawEndDate = query.DrawStartDate.AddHours(query.DrawDuration.DrawDurationValue),
                ProductName = query.Product.ProductValue,
                DrawCategory = query.DrawCategory.DrawCategoryValue,
                FirstName = query.User.FirstName,
                DrawDuration = query.DrawDuration.DrawDurationValue,
                DrawSize = query.DrawSize.DrawSizeValue,
                DrawPriority = query.DrawPriority.DrawPriorityValue,
                DrawName = query.DrawName,
                DrawFacebookAddress = query.DrawFaceBookAddress
            };
        }
    }
}
