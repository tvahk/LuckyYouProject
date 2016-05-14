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
    public class WinningRepository : EFRepository<Winning>, IWinningRepository
    {
        public WinningRepository(IDbContext dbContext) : base(dbContext)
        {         
        }

        public List<Winning> GetUserWinnings(string userid)
        {
            return DbSet.Where(x => x.UserId == userid).Include(y => y.User).Include(z => z.Draw).ToList();
        }

        public List<Winning> GetAllWinningsWithUserAndDraws()
        {
            return DbSet.Include(x => x.Draw).Include(y => y.User).ToList();
        }

        public int CountUserWinnings(string userid)
        {
            return DbSet.Count(x => x.UserId == userid);
        }
    }
}
