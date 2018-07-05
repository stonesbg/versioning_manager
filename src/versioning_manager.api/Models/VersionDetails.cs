using System;
using versioning_manager.contracts.Models;
using LiteDB;
using versioning_manager.api.Controllers;

namespace versioning_manager.api.Models
{
  public class VersionDetail : IVersionDetail
  {
    [BsonId]
    public int Id { get; set; }

    public Version Version { get; set; }

    public DateTime CreatedDate { get; set; }

    [BsonRef]
    public IProduct Product { get; set; }

  }

}
