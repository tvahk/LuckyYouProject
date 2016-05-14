using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class BillRepository : EFRepository<Bill>, IBillRepository
    {
        public BillRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public List<Bill> getBillByDrawId(int drawId)
        {
            return DbSet.Where(x => x.DrawId == drawId).Include(y => y.Draw).ToList();
        }

        public List<Bill> getAllBills()
        {
            return
                DbSet.Include(y => y.Draw).ToList();
        }

        


    }
}
