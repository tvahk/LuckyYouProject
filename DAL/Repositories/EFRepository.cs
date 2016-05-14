using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DAL.Interfaces;
using NLog;

namespace DAL.Repositories
{
    // this is universal base EF repository implementation, to be included in all other repos
    // covers all basic crud methods, common for all other repos
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly string _instanceId = Guid.NewGuid().ToString();

        // the context and the dbset we are working with
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        //Constructor, requires dbContext as dependency
        public EFRepository(IDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");

            DbContext = dbContext as DbContext;
            //get the dbset from context
            if (DbContext != null) DbSet = DbContext.Set<T>();

			_logger.Info("_instanceId: " + _instanceId + " dbSet: " + DbSet.GetType());
        }

		public List<T> All
		{
			get { return DbSet.ToList(); }
		}

		public T GetById(object id)
		{
			return DbSet.Find(id);
		}

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public EntityKey GetPrimaryKeyInfo(T entity)
        {
            var properties = typeof(DbSet).GetProperties();
            foreach (var objectContext in properties.Select(propertyInfo => ((IObjectContextAdapter)DbContext).ObjectContext))
            {
                ObjectStateEntry objectStateEntry;
                if (null != entity && objectContext.ObjectStateManager
                    .TryGetObjectStateEntry(entity, out objectStateEntry))
                {
                    return objectStateEntry.EntityKey;
                }
            }
            return null;
        }

        public string[] GetKeyNames(T entity)
        {
            var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<T>();
            var keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
            return keyNames;
        }

        public void Dispose()
        {
			_logger.Info("_instanceId: " + _instanceId);
        }
    }
}