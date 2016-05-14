using System.Collections.Generic;
using DomainLogic.IdentityModels;

namespace DAL.Interfaces
{
	public interface IUserRepository : IEFRepository<User>
	{
		User GetUserByUserName(string userName);
	    List<User> GetAllUserNames();
	    List<User> GetUsersByScore();
        User GetUserByEmail(string email);
        bool IsInRole(string userId, string roleName);
	}
}
