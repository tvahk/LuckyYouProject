using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DomainLogic.ApiModel;

namespace DALWebApi.Interfaces
{
    public interface IDrawRepository : IWebApiRepository<DrawAPI>
    {
        ICollection<DrawAPI> AllDrawsByCategory(int categoryId);
        DrawAPI DrawByDrawId(int drawId);
    }
}
