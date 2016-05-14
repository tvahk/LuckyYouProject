using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IDrawRepository : IEFRepository<Draw>
    {
        List<Draw> GetUserDrawsByUserId(string userid);
        List<Draw> GetDrawsByDrawCategory(int drawCategoryId);
        List<Draw> GetDrawsBySize(int drawSizeId);
        List<Draw> GetDrawsByDuration(int drawDurationId);
        Draw GetDrawByProductId(int productId);
        List<Draw> GetAllDraws();
        List<Draw> GetAllDrawsByDurationId(int duartionId);
      List<Draw> GetDrawsByPriority(int drawPriorityId);
    }
}
