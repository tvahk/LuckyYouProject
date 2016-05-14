using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DomainLogic.IdentityModels;

namespace DAL.Repositories
{
	public class UserRepository : EFRepository<User>, IUserRepository
	{
		public UserRepository(IDbContext dbContext) : base(dbContext)
		{
		}

		public User GetUserByUserName(string userName)
		{
			return DbSet.FirstOrDefault(a => a.UserName.ToUpper() == userName.ToUpper());
		}

        public List<User> GetAllUserNames()
	    {
	        return DbSet.ToList();
	    }

	    public List<User> GetUsersByScore()
	    {
	        return DbSet.OrderByDescending(x => x.Score).ToList();
	    }


	    public User GetUserByEmail(string email)
		{
			return DbSet.FirstOrDefault(a => a.Email.ToUpper() == email.ToUpper());
		}

	    public bool IsInRole(string userId, string roleName)
	    {
            return DbSet.Find(userId).Roles.Any(a => a.Role.Name == roleName);
	    }
    }
}
