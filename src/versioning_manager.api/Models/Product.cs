using versioning_manager.contracts.Models;

namespace versioning_manager.api.Controllers
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
