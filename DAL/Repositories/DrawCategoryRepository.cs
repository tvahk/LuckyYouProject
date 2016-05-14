using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class DrawCategoryRepository : EFRepository<DrawCategory>, IDrawCategoryRepository
    {
        public DrawCategoryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<DrawCategory> GetAllDrawCategories()
        {
            return DbSet.Include(x => x.DrawCategoryValue).Include(y => y.Draws).ToList();
        }


    }
}
