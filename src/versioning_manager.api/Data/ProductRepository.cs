using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;

namespace versioning_manager.api.Controllers
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<IProduct> GetAll()
        {
            return new List<IProduct>();
        }
    }
}
