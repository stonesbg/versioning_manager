using System.Collections.Generic;
using versioning_manager.data.Models;

namespace versioning_manager.contracts.Services
{
  public interface IProductService
  {
    IEnumerable<Product> GetAll();

    void Add(Product product);
  }
}
