using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
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