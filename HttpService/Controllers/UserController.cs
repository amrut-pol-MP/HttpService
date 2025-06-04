using Grpc.Core;
using HttpService.Models.Common;
using HttpService.Services.User;
using HttpService.Services.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpService.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Create User.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(CreateUserCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var response = _userService.CreateUser(request);
                return Ok(response);
            }
            catch (RpcException e)
            {
                var errorModel = new { Message = e.Status.Detail, Code = e.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(e.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Get user data by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var res = _userService.GetUser(id);
                return Ok(res);
            }
            catch (RpcException e)
            {
                var errorModel = new { Message = e.Status.Detail, Code = e.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(e.StatusCode, errorModel, this);
            }
        }

        /// <summary>
        /// Query users.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("QueryUsers")]
        public IActionResult QueryUsers([FromQuery] QueryUserCommandRequest request)
        {
            try
            {
                var result = _userService.QueryUsers(request);
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
        /// Update user.
        /// </summary>
        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _userService.UpdateUser(id, request);
                return new NoContentResult();
            }
            catch (RpcException ex)
            {
                var errorModel = new { Message = ex.Status.Detail, Code = ex.StatusCode.ToString() };
                return GrpcErrorHandler.HandleGrpcError(ex.StatusCode, errorModel, this);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);

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
