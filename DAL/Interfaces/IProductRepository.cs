using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IProductRepository : IEFRepository<Product>
    {
        List<Product> getAllUserProducts(string userid);
        List<Product> getAllProductsIncludeOthers();
        List<Product> getProductsbyProductTypeId(int productTypeId);
    }
}