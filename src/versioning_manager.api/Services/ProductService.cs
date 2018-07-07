using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Services;
using versioning_manager.data.Models;

namespace versioning_manager.api.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(Product product)
        {
          _repository.Add(product);
        }
  }
}
