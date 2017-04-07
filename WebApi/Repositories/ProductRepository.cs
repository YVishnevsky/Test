using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSample.Models;

namespace WebApiSample.Repositories
{
    public class FakeRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public Product Add(Product product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id + 1) : 1;
            _products.Add(product);

            return product;
        }

        public void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }

        public void Remove(int productId)
        {
            var existingProduct = _products.First(p => p.Id == productId);
            if (existingProduct == null)
            {
                throw new ArgumentException();
            }

            _products.Remove(existingProduct);
        }

        public IEnumerable<Product> GetPage(int pageNum, int pageSize)
        {
            return _products.OrderBy(p => p.Id).Skip(pageSize * --pageNum).Take(pageSize);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
