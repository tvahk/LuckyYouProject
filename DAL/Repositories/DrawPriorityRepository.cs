using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class DrawPriorityRepository : EFRepository<DrawPriority>, IDrawPriorityRepository
    {
        public DrawPriorityRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }
        public DrawPriority GetDrawPriorityPrice(int priorityId)
        {
            return DbSet.FirstOrDefault(x => x.DrawPriorityId == priorityId);
        }
    }
}
