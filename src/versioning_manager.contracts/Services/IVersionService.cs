using System;
using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Services
{
    public interface IVersionService
    {
        IEnumerable<IVersionDetail> GetVersions(IVersionRequest request);

        IVersionDetail IncrementVersion(IVersionRequest request);
    }

    public interface IVersionRequest
    {
        int ProductId { get; set; }
        int? Major {get; set;}

        int? Minor { get; set; }
    }

}
