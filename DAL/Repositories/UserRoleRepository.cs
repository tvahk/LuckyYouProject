using System.Linq;
using DAL.Interfaces;
using DomainLogic.IdentityModels;

namespace DAL.Repositories
{
	public class UserRoleRepository : EFRepository<UserRole>, IUserRoleRepository
	{
        public UserRoleRepository(IDbContext dbContext)
            : base(dbContext)
		{
		}

	    public UserRole GetByUserIdAndRoleId(object roleId, object userId)
	    {
	        return DbSet.FirstOrDefault(a => a.RoleId == roleId && a.UserId == userId);
	    }

	}
}
