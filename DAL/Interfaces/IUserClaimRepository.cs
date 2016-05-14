using System.Collections.Generic;
using DomainLogic.IdentityModels;

namespace DAL.Interfaces
{
	public interface IUserClaimRepository : IEFRepository<UserClaim>
	{
	    List<UserClaim> AllIncludeUser();
	}
}
