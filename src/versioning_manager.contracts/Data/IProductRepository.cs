using System.Collections.Generic;
using versioning_manager.data.Models;

namespace versioning_manager.contracts.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product Add(Product product);
    }
}
