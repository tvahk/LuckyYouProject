using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class DrawDurationRepository : EFRepository<DrawDuration>, IDrawDurationRepository
    {
        public DrawDurationRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }

        public DrawDuration GetDrawDurationPrice(int durationId)
        {
            return DbSet.FirstOrDefault(x => x.DrawDurationId == durationId);
        }
    }
}
