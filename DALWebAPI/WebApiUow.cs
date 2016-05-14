using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALWebApi.Interfaces;
using DALWebApi.Repositories;

namespace DALWebApi
{
    /// <summary>
    /// UOW, using WEB-API based repos
    /// </summary>
    public class WebApiUow : IWebApiUOW
    {
        private readonly IDictionary<Type, Func<string, object>> _repositoryFactories;
        protected Dictionary<Type, object> Repositories { get; private set; }

        public WebApiUow()
        {
            //list of factories for our repos
            _repositoryFactories = GetCustomFactories();
            //here we cache already created repos
            Repositories = new Dictionary<Type, object>();
        }
        public void Commit()
        {
            // hmm, do nothing?
        }


        public IDrawRepository Draws { get { return GetWebApiRepo<IDrawRepository>("https://localhost:44300/api/draws/"); } }
        public IDrawCategoryRepository DrawCategory { get { return GetWebApiRepo<IDrawCategoryRepository>("https://localhost:44300/api/drawcategory/"); } }
        public IDrawDurationRepository DrawDuration { get { return GetWebApiRepo<IDrawDurationRepository>("https://localhost:44300/api/drawduration/"); } }
        public IDrawPriorityRepository DrawPriority { get { return GetWebApiRepo<IDrawPriorityRepository>("https://localhost:44300/api/drawpriority/"); } }
        public IDrawSizeRepository DrawSize { get { return GetWebApiRepo<IDrawSizeRepository>("https://localhost:44300/api/drawsize/"); } }
        public IProductRepository Product { get { return GetWebApiRepo<IProductRepository>("https://localhost:44300/api/products/"); } }
        public IUserRepository User { get { return GetWebApiRepo<IUserRepository>("https://localhost:44300/api/users/"); } }


        // calling custom repo provier
        private T GetWebApiRepo<T>(string baseUrl) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            return MakeRepository<T>(baseUrl);
        }

        protected virtual T MakeRepository<T>(string baseUrl)
        {
            Func<string, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            if (factory == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)factory(baseUrl);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        private static IDictionary<Type, Func<string, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<string, object>>
                {
                    {typeof(IDrawRepository), baseUrl => new DrawRepository(baseUrl)},
                     {typeof(IDrawCategoryRepository), baseUrl => new DrawCategoryRepository(baseUrl)},
                      {typeof(IDrawDurationRepository), baseUrl => new DrawDurationRepository(baseUrl)},
                       {typeof(IDrawPriorityRepository), baseUrl => new DrawPriorityRepository(baseUrl)},
                        {typeof(IDrawSizeRepository), baseUrl => new DrawSizeRepository(baseUrl)},
                         {typeof(IProductRepository), baseUrl => new ProductRepository(baseUrl)},
                          {typeof(IUserRepository), baseUrl => new UserRepository(baseUrl)},
                };
        }

    }
}
