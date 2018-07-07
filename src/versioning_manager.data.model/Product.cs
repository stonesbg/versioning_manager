using LiteDB;

namespace versioning_manager.data.Models
{
  public class Product
  {
    [BsonId]
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    [BsonRef("organization")]
    public Organization Organization { get; set; }
  }
}
