using System;
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
        public ActionResult<IEnumerable<VersionDetail>> GetVersions(VersionRequest versionRequests)
        {
            try
            {
                var versionList = _service.GetVersions(versionRequests);
                return Ok(versionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("increment")]
        public ActionResult<VersionDetail> IncrementVersion(VersionRequest versionRequests)
        {
            try
            {
                var increment = _service.IncrementVersion(versionRequests);
                return Ok(increment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
