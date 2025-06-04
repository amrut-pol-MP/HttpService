using Grpc.Core;
using HttpService.Configuration;
using HttpService.Services.Organization;
using HttpService.Services.Organization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HttpService.Controllers
{
    [ApiController]
    [Route("api/Organization")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        /// <summary>
        /// Create Organization.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateOrganization")]
        public IActionResult CreateOrganization(CreateOrganizationCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var response = _organizationService.CreateOrganization(request);
                return Ok(response);
            }
            catch (RpcException e)
            {
                var errorModel = new { Message = e.Status.Detail, Code = e.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(e.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Get organization data by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetOrganization/{id}")]
        public IActionResult GetOrganization(int id)
        {
            try
            {
                var res = _organizationService.GetOrganization(id);
                return Ok(res);
            }
            catch (RpcException e)
            {
                var errorModel = new { Message = e.Status.Detail, Code = e.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(e.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Query organization.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("QueryOrganizations")]
        public IActionResult QueryOrganizations([FromQuery] QueryOrganizationCommandRequest request)
        {
            try
            {
                var result = _organizationService.QueryOrganizations(request);
                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (RpcException ex)
            {
                var errorModel = new { Message = ex.Status.Detail, Code = ex.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(ex.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Update organization.
        /// </summary>
        [HttpPut("UpdateOrganization/{id}")]
        public IActionResult UpdateOrganization(int id, [FromBody] UpdateOrganizationCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _organizationService.UpdateOrganization(id, request);
                return new NoContentResult();
            }
            catch (RpcException ex)
            {
                var errorModel = new { Message = ex.Status.Detail, Code = ex.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(ex.StatusCode, errorModel, this);
            }
        }

        [HttpDelete("DeleteOrganization/{id}")]
        public IActionResult DeleteOrganization(int id)
        {
            try
            {
                _organizationService.DeleteOrganization(id);

                return new NoContentResult();
            }
            catch (RpcException ex)
            {
                var errorModel = new { Message = ex.Status.Detail, Code = ex.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(ex.StatusCode, errorModel, this);
            }
        }
    }
}
