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

namespace NPaperless.Services.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class TasksApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ackTasksRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/acknowledge_tasks")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("AckTasks")]
        [SwaggerResponse(statusCode: 200, type: typeof(AckTasks200Response), description: "Success")]
        public virtual IActionResult AckTasks([FromBody]AckTasksRequest ackTasksRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AckTasks200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"result\" : 0\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<AckTasks200Response>(exampleJson)
            : default(AckTasks200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/tasks")]
        [ValidateModelState]
        [SwaggerOperation("GetTasks")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<GetTasks200ResponseInner>), description: "Success")]
        public virtual IActionResult GetTasks()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<GetTasks200ResponseInner>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"date_done\" : \"date_done\",\n  \"result\" : \"result\",\n  \"acknowledged\" : true,\n  \"task_file_name\" : \"task_file_name\",\n  \"date_created\" : \"date_created\",\n  \"related_document\" : \"related_document\",\n  \"task_id\" : \"task_id\",\n  \"id\" : 0,\n  \"type\" : \"type\",\n  \"status\" : \"status\"\n}, {\n  \"date_done\" : \"date_done\",\n  \"result\" : \"result\",\n  \"acknowledged\" : true,\n  \"task_file_name\" : \"task_file_name\",\n  \"date_created\" : \"date_created\",\n  \"related_document\" : \"related_document\",\n  \"task_id\" : \"task_id\",\n  \"id\" : 0,\n  \"type\" : \"type\",\n  \"status\" : \"status\"\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<GetTasks200ResponseInner>>(exampleJson)
            : default(List<GetTasks200ResponseInner>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
