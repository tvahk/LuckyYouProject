using System;
using System.Data.Entity;
using DAL.Interfaces;
using Domain;
using DomainLogic.IdentityModels;
using NLog;

namespace DAL
{
    public class UOW : IUOW, IDisposable
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly string _instanceId = Guid.NewGuid().ToString();

		private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext)
        {
			_logger.Info("_instanceId: " + _instanceId);

            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext)DbContext).SaveChanges();
        }
        //standard repos
        
        public IEFRepository<DrawCategory> DrawCategories => GetStandardRepo<DrawCategory>();
        public IEFRepository<Product> Products => GetStandardRepo<Product>();
        public IEFRepository<ProductType> ProductTypes => GetStandardRepo<ProductType>();
        public IEFRepository<Winning> Winnings => GetStandardRepo<Winning>();

        public IEFRepository<Bill> Bills => GetStandardRepo<Bill>();
        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories
        public IDrawRepository Draws => GetRepo<IDrawRepository>();
        public IUserInDrawRepository UserInDraws => GetRepo<IUserInDrawRepository>();
        public IUserRepository Users { get { return GetRepo<IUserRepository>(); } }
        public IUserRoleRepository UserRoles { get { return GetRepo<IUserRoleRepository>(); } }
        public IRoleRepository Roles { get { return GetRepo<IRoleRepository>(); } }
		public IUserClaimRepository UserClaims { get { return GetRepo<IUserClaimRepository>(); } }
        public IUserLoginRepository UserLogins { get { return GetRepo<IUserLoginRepository>(); } }

        public IDrawDurationRepository DrawDurations { get { return GetRepo<IDrawDurationRepository>(); } }
        public IDrawPriorityRepository DrawPriorities { get { return GetRepo<IDrawPriorityRepository>(); } }
        public IDrawSizeRepository DrawSizes { get { return GetRepo<IDrawSizeRepository>(); } }

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
			_logger.Info("Disposing: " + disposing + " _instanceId: " + _instanceId);
        }

        #endregion

    }
}
