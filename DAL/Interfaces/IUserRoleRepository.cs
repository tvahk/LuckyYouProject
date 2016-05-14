using DomainLogic.IdentityModels;

namespace DAL.Interfaces
{
	public interface IUserRoleRepository : IEFRepository<UserRole>
	{
	    UserRole GetByUserIdAndRoleId(object roleId, object userId);

	}
}
