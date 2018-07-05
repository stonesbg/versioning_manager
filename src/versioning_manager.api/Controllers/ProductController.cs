using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using versioning_manager.api.Models;
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
        return _service.GetAll().ToList(); ;
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpPost]
    public ActionResult Add(ProductCreateRequest request)
    {
      try
      {
        var product = new Product
        {
          Name = request.Name,
          Description = request.Description,
          Organization = new Organization
          {
            Id = request.OrgId
          }
        };

        _service.Add(product);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

  }

}
