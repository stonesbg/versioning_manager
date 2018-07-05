using System;
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


        public ActionResult<VersionDetail> GetVersion()
        {
            try
            {
                return _service.GetVersion() as VersionDetail;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("test")]
        public IVersionDetail GetVersion(VersionRequest versionRequests)
        {
            if (versionRequests.Major.HasValue)
            {
                return _service.GetVersion(versionRequests.Major.Value);
            }

            return null;
        }

        [HttpGet("{major}")]
        public IVersionDetail GetVersion(int major)
        {
            return _service.GetVersion(major);
        }

        [HttpGet("{major}/{minor}")]
        public IVersionDetail GetVersion(int major, int minor)
        {
            return _service.GetVersion(major, minor);
        }

        [HttpGet("{major}/{minor}/{build}")]
        public IVersionDetail GetVersion(int major, int minor, int build)
        {
            return _service.GetVersion(major, minor, build);
        }

        [HttpGet("{major}/{minor}/{build}/{revision}")]
        public IVersionDetail GetVersion(int major, int minor, int build, int revision)
        {
            return _service.GetVersion(major, minor, build, revision);
        }

        [HttpPatch("increment/major")]
        public IVersionDetail IncrementMajorVersion()
        {
            return _service.IncrementMajorVersion();
        }

        [HttpPatch("increment/minor")]
        public IVersionDetail IncrementMinorVersion()
        {
            return _service.IncrementMinorVersion();
        }

        [HttpPatch("increment/build")]
        public IVersionDetail IncrementBuildVersion()
        {
            return _service.IncrementBuildVersion();
        }

        [HttpPatch("increment/revision")]
        public IVersionDetail IncrementRevisionVersion()
        {
            return _service.IncrementRevisionVersion();
        }
    }
}
