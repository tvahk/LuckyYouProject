using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class DrawSizeRepository : EFRepository<DrawSize>, IDrawSizeRepository
    {
        public DrawSizeRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }

        public DrawSize GetDrawSizePrice(int sizeId)
        {
            return DbSet.FirstOrDefault(x => x.DrawSizeId == sizeId);
        }
    }
}
