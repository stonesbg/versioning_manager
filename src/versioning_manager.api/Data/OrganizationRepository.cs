using System;
using System.Collections.Generic;
using versioning_manager.api.Models;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;

namespace versioning_manager.api.Controllers
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public IEnumerable<IOrganization> GetAll()
        {
            //return new List<Version>();
            return new List<IOrganization>();
        }
    }

}
