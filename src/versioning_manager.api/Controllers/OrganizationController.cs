using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using versioning_manager.contracts.Models;
using versioning_manager.contracts.Services;

namespace versioning_manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        IOrganizationService _service;
        public OrganizationController(IOrganizationService service)
        {
            _service = service;
        }

        public ActionResult<List<IOrganization>> GetOrganizations()
        {
            try
            {
                return _service.GetOrganizations().ToList(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
