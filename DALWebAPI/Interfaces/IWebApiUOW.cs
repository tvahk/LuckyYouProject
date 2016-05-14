using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWebApi.Interfaces
{
    public interface IWebApiUOW
    {
        //save pending changes to the data store
        void Commit();

        IDrawRepository Draws { get; }
        IDrawCategoryRepository DrawCategory{ get; }
        IDrawDurationRepository DrawDuration { get; }
        IDrawPriorityRepository DrawPriority { get; }
        IDrawSizeRepository DrawSize { get; }
        IProductRepository Product { get; }
        IUserRepository User { get; }
    }

}
