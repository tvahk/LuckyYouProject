using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using DomainLogic.IdentityModels;

namespace DAL.Repositories
{
	public class UserClaimRepository : EFRepository<UserClaim>, IUserClaimRepository
	{
		public UserClaimRepository(IDbContext dbContext) : base(dbContext)
		{
		}

	    public List<UserClaim> AllIncludeUser()
	    {
	        return DbSet.Include(a => a.User).ToList();

	    }

	}
}
