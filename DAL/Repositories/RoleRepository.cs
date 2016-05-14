using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DomainLogic.IdentityModels;

namespace DAL.Repositories
{
	public class RoleRepository : EFRepository<Role>, IRoleRepository
	{
		public RoleRepository(IDbContext dbContext) : base(dbContext)
		{
		}

        /// <summary>
        /// Gets role by role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
	    public Role GetByRoleName(string roleName)
	    {
            return DbSet.FirstOrDefault(a => a.Name.ToUpper() == roleName.ToUpper());

	    }

        /// <summary>
        /// Gets roles for user by user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
	    public List<Role> GetRolesForUser(string userId)
	    {
	        return (from role in DbSet from user in role.Users.Where(a => a.UserId == userId) select role).ToList();
	    }
	}
}
