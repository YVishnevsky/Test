using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi
{
    [RoutePrefix("api/products")]
    public class ProductController: ApiController
    {
        IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [Route(""), HttpPost]
        public Product Add(Product product)
        {
            _repository.Add(product);

            return product;
        }

        [Route("{id}"), HttpPut]
        public void Update(int id, Product product)
        {
            product.Id = id;
            _repository.Update(product);
        }

        [Route("{id}"), HttpDelete]
        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        /// <summary>
        /// simple paged data
        /// GET api/products?pagenum=x&pagesize=y
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Product> GetPage(int pageNum, int pageSize)
        {
            return _repository.GetPage(pageNum, pageSize);
        }
    }
}
