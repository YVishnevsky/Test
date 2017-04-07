using System.Collections.Generic;
using WebApiSample.Models;

namespace WebApiSample.Repositories
{
    public interface IProductRepository
    {
        Product Add(Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetPage(int pageNum, int pageSize);
        void Remove(int productId);
        void Update(Product product);
    }
}