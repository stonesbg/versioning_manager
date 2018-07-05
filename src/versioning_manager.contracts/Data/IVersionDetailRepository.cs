using System;
using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Data
{
    public interface IVersionDetailRepository
    {
        IEnumerable<IVersionDetail> GetAll();

        IEnumerable<IVersionDetail> GetByProductId(int productId);

        void Add(IVersionDetail version);
    }

}
