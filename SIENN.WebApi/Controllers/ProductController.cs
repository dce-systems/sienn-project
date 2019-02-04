using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIENN.Services.Models.DTO.Product;
using SIENN.Services.Models.Extensions;
using SIENN.Services.Abstractions;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger _logger;

        private const string LogErrorText = "Something go wrong ;(, exception message: {0}!";
        private const string BadRequestText = "Something go wrong while {0}. Are you sure you are doing it the right way?";

        public ProductController(IProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while loading products. Please try a bit later");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "loading products"));
            }
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            try
            {
                return Ok(_service.Count());
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "calculating products"));
            }
        }

        [HttpGet("{id}/info")]
        public IActionResult ShowInfo(int id)
        {
            try
            {
                return Ok(_service.ShowInfo(id));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "showing info about product"));
            }
        }

        [HttpGet("page/{pageNumber:int}/pageSize/{pageSize:int}")]
        public IActionResult GetRangeWithAvailable(int pageNumber, int pageSize, bool? available = null)
        {
            try
            {
                return Ok(_service.GetRangeWithAvailable(pageNumber, pageSize, available));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "loading products"));
            }
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] ProductFiltersDto request)
        {
            try
            {
                return Ok(_service.Search(request));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "searching products"));
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductCreationDto request)
        {
            try
            {
                _service.Add(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "adding product"));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductUpdateDto request)
        {
            try
            {
                _service.Update(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "updating product"));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _service.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "deleteing product"));
            }
        }
    }
}
