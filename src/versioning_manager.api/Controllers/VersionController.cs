using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using versioning_manager.api.Models;
using versioning_manager.contracts.Models;
using versioning_manager.contracts.Services;

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

        [HttpGet()]
        public IEnumerable<IVersionDetail> GetVersions([FromBody] IVersionRequest versionRequests)
        {
            return _service.GetVersions(versionRequests);
        }

        [HttpPatch("increment")]
        public IVersionDetail IncrementVersion(IVersionRequest versionRequests)
        {
            return _service.IncrementVersion(versionRequests);
        }
    }
}
