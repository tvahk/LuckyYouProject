using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DrawCategoryService
    {
        private DAL.Interfaces.IDrawCategoryRepository _repo;
        private Factories.DrawCategoryFactory _factory;

        public DrawCategoryService()
        {
            this._repo = new DAL.Repositories.DrawCategoryRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.DrawCategoryFactory();
        }

        public List<DTO.DrawCategoryDTO> getAllDrawCategories()
        {
            return
               this._repo.All.Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.DrawCategoryDTO getDrawCategoryById(int id)
        {
            var query = _repo.All.Where(x => _factory.createBasicDTO(x).DrawCategoryId == id).FirstOrDefault();
            return new DTO.DrawCategoryDTO()
            {
                DrawCategoryId = query.DrawCategoryId,
                DrawCategoryValue = query.DrawCategoryValue,
            };
        }
    }
}
