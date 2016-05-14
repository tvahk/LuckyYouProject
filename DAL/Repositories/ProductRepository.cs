using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {           
        }

        public List<Product> getAllUserProducts(string userid)
        {
            return DbSet.Where(x => x.UserId == userid).Include(y => y.User).Include(a => a.ProductType).ToList();
        }

        public List<Product> getAllProductsIncludeOthers()
        {
            return DbSet.Include(y => y.User).Include(a => a.ProductType).ToList();
        }

        public List<Product> getProductsbyProductTypeId(int productTypeId)
        {
            return DbSet.Where(x => x.ProductTypeId == productTypeId).ToList();
        }

    }
}
