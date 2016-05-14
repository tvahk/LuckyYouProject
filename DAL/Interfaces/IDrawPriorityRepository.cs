using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IDrawPriorityRepository : IEFRepository<DrawPriority>
    {
        DrawPriority GetDrawPriorityPrice(int priorityId);
    }
}