namespace versioning_manager.contracts.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }

        string Description { get; set; }

        IOrganization Organization { get; set; }
  }
}
