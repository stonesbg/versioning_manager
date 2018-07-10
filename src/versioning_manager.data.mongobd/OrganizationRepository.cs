using System.Collections.Generic;
using versioning_manager.data.Models;

namespace versioning_manager.data.mongodb
{
    public interface IOrganizationRepository
    {
        IEnumerable<Organization> GetAll();

        void Add(Organization org);
    }
}
