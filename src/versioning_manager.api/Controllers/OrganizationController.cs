using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using versioning_manager.contracts.Services;
using versioning_manager.data.Models;

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

        [HttpGet]
        public ActionResult<List<Organization>> GetAll()
        {
            try
            {
                return _service.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Organization> Get(int id)
        {
            return _service.Get(id) as Organization;
        }

        [HttpPost]
        public ActionResult<Organization> Add(Organization org)
        {
            try
            {
                return _service.Add(org) as Organization;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
