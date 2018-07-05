using versioning_manager.contracts.Models;

namespace versioning_manager.api.Models
{
    public class Organization : IOrganization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
