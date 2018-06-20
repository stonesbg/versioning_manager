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
    public class ProductController : ControllerBase
    {
        IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        public ActionResult<List<IProduct>> GetProducts()
        {
            try
            {
                return _service.GetProducts().ToList(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
