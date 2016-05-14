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
    public class UserInDrawRepository : EFRepository<UserInDraw>, IUserInDrawRepository
    {
        public UserInDrawRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<UserInDraw> GetAllUserInDrawsIncludedUserAndDraws()
        {
            return DbSet.Include(y => y.Draw).Include(z => z.User).ToList();
        }
    }
}