using LiteDB;
using System;

namespace versioning_manager.data.Models
{
  public class VersionDetail
  {
    [BsonId]
    public int Id { get; set; }

    public Version Version { get; set; }

    public DateTime CreatedDate { get; set; }

    [BsonRef]
    public Product Product { get; set; }

  }

}
