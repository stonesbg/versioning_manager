using System;
using System.Collections.Generic;
using versioning_manager.contracts.Data;

namespace versioning_manager.api.Controllers
{
    public class VersionRepository : IVersionRepository
    {
        public IEnumerable<Version> GetAll()
        {
            //return new List<Version>();
            return new List<Version>();
        }
    }

}
