using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Data
{
    public interface IOrganizationRepository
    {
        IEnumerable<IOrganization> GetAll();
    }
}
