using LiteDB;
using versioning_manager.api.Models;
using versioning_manager.contracts.Models;

namespace versioning_manager.api.Controllers
{
  public class Product : IProduct
  {
    [BsonId]
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    [BsonRef("organization")]
    public IOrganization Organization { get; set; }
  }
}
