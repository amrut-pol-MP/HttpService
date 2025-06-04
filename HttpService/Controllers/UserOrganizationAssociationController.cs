using Grpc.Core;
using HttpService.Configuration;
using HttpService.Services.UserOrganizationAssociation;
using HttpService.Services.UserOrganizationAssociation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpService.Controllers
{
    [ApiController]
    [Route("api/UserOrganizationAssociation")]
    public class UserOrganizationAssociationController : ControllerBase
    {
        private readonly IUserOrganizationAssociationService _userOrganizationAssociation;

        public UserOrganizationAssociationController(IUserOrganizationAssociationService userOrganizationAssociation)
        {
            _userOrganizationAssociation = userOrganizationAssociation;
        }
        /// <summary>
        /// Associate User To Organization.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AssociateUserToOrganization")]
        public IActionResult AssociateUserToOrganization(AssociateUserToOrganizationCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var response = _userOrganizationAssociation.AssociateUserToOrganization(request);
                return Ok(response);
            }
            catch (RpcException e)
            {
                var errorModel = new { Message = e.Status.Detail, Code = e.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(e.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Disassociate User from Organization.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DisassociateUserFromOrganization")]
        public IActionResult DisassociateUserFromOrganization(DisassociateUserFromOrganizationCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _userOrganizationAssociation.DisassociateUserFromOrganization(request);
                return new NoContentResult();
            }
            catch (RpcException e)
            {
                var errorModel = new { Message = e.Status.Detail, Code = e.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(e.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Query Users For Organization.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("QueryUsersForOrganization")]
        public IActionResult QueryUsersForOrganization([FromQuery] QueryUsersForOrganizationCommandRequest request)
        {
            try
            {
                var result = _userOrganizationAssociation.QueryUsersForOrganization(request);
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
    }
}
