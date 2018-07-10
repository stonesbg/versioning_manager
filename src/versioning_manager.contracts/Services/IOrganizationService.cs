using System.Collections.Generic;
using versioning_manager.data.Models;

namespace versioning_manager.contracts.Services
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetAll();

        Organization Get(int id);

        Organization Add(Organization org);
    }
}
