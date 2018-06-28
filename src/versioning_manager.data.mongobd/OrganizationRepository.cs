using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.data.mongodb
{
    public interface IOrganizationRepository
    {
        IEnumerable<IOrganization> GetAll();

        void Add(IOrganization org);
    }
}
