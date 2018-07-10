using System.Collections.Generic;
using versioning_manager.data.Models;

namespace versioning_manager.contracts.Data
{
    public interface IVersionDetailRepository
    {
        IEnumerable<VersionDetail> GetAll();

        IEnumerable<VersionDetail> GetByProductId(int productId);

        VersionDetail Add(VersionDetail version);
    }

}
