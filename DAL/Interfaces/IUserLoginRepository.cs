using System.Collections.Generic;
using DomainLogic.IdentityModels;

namespace DAL.Interfaces
{
	public interface IUserLoginRepository : IEFRepository<UserLogin>
	{
	    List<UserLogin> GetAllIncludeUser();
        UserLogin GetUserLoginByProviderAndProviderKey(string loginProvider, string providerKey);
	}
}
