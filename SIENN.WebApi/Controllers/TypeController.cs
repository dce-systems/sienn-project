﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIENN.Services.Models.DTO.Type;
using SIENN.Services.Models.Extensions;
using SIENN.Services.Abstractions;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Type")]
    public class TypeController : Controller
    {
        private readonly ITypeService _service;
        private readonly ILogger _logger;

        private const string LogErrorText = "Something go wrong ;(, exception message: {0}!";
        private const string BadRequestText = "Something go wrong while {0}. Are you sure you are doing it the right way?";

        public TypeController(ITypeService service, ILogger<TypeController> logger)
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
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "loading types"));
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
                return BadRequest(String.Format(BadRequestText, "loading type"));
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
                return BadRequest(String.Format(BadRequestText, "calculating types"));
            }
        }

        [HttpGet("page/{pageNumber:int}/pageSize/{pageSize:int}")]
        public IActionResult GetRange(int pageNumber, int pageSize)
        {
            try
            {
                return Ok(_service.GetRange(pageNumber, pageSize));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "loading types"));
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] TypeCreationDto request)
        {
            try
            {
                _service.Add(request.ToEntity());
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "adding type"));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] TypeUpdateDto request)
        {
            try
            {
                _service.Update(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, String.Format(LogErrorText, e.Message));
                return BadRequest(String.Format(BadRequestText, "updating type"));
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
                return BadRequest(String.Format(BadRequestText, "deleting type"));
            }
        }

    }
}
