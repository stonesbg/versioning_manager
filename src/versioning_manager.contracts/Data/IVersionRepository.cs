using System;
using System.Collections.Generic;

namespace versioning_manager.contracts.Data
{
    public interface IVersionRepository
    {
        IEnumerable<Version> GetAll();
    }

}
