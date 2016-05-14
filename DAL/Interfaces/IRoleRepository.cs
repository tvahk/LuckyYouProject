using System.Collections.Generic;
using DomainLogic.IdentityModels;

namespace DAL.Interfaces
{
	public interface IRoleRepository : IEFRepository<Role>
	{
	    Role GetByRoleName(string roleName);
	    List<Role> GetRolesForUser(string userId);
	}
}
