using System;
using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Data
{
    public interface IVersionDetailRepository
    {
        IEnumerable<IVersionDetail> GetAll();

        void Add(IVersionDetail version);
    }

}
