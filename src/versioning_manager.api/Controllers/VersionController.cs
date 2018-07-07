using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using versioning_manager.contracts.Services;
using versioning_manager.data.Models;

namespace versioning_manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        IVersionService _service;

        public VersionController(IVersionService service)
        {
            _service = service;
        }

        [HttpPost("show")]
        public IEnumerable<VersionDetail> GetVersions(VersionRequest versionRequests)
        {
            return _service.GetVersions(versionRequests);
        }

        [HttpPatch("increment")]
        public VersionDetail IncrementVersion(VersionRequest versionRequests)
        {
            return _service.IncrementVersion(versionRequests);
        }
    }
}
