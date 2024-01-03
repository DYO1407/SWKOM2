/*
 * Paperless Rest Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NPaperless.Services.Attributes;
using NPaperless.Services.DTOs;
using AutoMapper;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace NPaperless.Services.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CorrespondentsApiController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICorrespondentLogic _correspondentLogic;
        private readonly ILogger<CorrespondentsApiController> _logger;

        public CorrespondentsApiController(IMapper mapper, ICorrespondentLogic correspondentLogic, ILogger<CorrespondentsApiController> logger)
        {
            _mapper = mapper;
            _correspondentLogic = correspondentLogic;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createCorrespondentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/correspondents")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateCorrespondent")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateCorrespondentRequest), description: "Success")]
        public virtual IActionResult CreateCorrespondent([FromBody] Correspondent createCorrespondentRequest)
        {
            var correspondentEntity = _mapper.Map<BusinessLogic.Entities.Correspondent>(createCorrespondentRequest);
            try
            {
                _correspondentLogic.CreateCorrespondent(correspondentEntity);
                _logger.LogInformation($"Created new Correspondet {JsonSerializer.Serialize(correspondentEntity)}");

            }
            catch(Exception ex)
            {
                
            }
            // to check if mapping works  
            return Ok(correspondentEntity);
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/correspondents/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteCorrespondent")]
        public virtual IActionResult DeleteCorrespondent([FromRoute(Name = "id")][Required] int id)
        {
            _correspondentLogic.DeleteCorrespondent(id);
            _logger.LogInformation($"Correspondent with ID {id} deleted");
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/correspondents")]
        [ValidateModelState]
        [SwaggerOperation("GetCorrespondents")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetCorrespondents200Response), description: "Success")]
        public virtual IActionResult GetCorrespondents([FromQuery(Name = "page")] int? page, [FromQuery(Name = "full_perms")] bool? fullPerms)
        {
            //var example = _correspondentLogic.GetCorrespondent(id);
            _correspondentLogic.GetCorrespondent((int)page);
            return Ok(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCorrespondentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/correspondents/{id}")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateCorrespondent")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateCorrespondent200Response), description: "Success")]
        public virtual IActionResult UpdateCorrespondent([FromRoute(Name = "id")][Required] int id, [FromBody] Correspondent updateCorrespondentRequest)
        {

            var correspondentEntity = _mapper.Map<BusinessLogic.Entities.Correspondent>(updateCorrespondentRequest);
            var example = _correspondentLogic.UpdateCorrespondent(correspondentEntity);
            _logger.LogInformation($"Correspondent updated to {JsonSerializer.Serialize(correspondentEntity)}");

            return new ObjectResult(example);
        }
    }
}
