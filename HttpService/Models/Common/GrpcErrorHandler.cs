using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace HttpService.Models.Common
{
    public static class GrpcErrorHandler
    {
        public static IActionResult HandleGrpcError(StatusCode statusCode, object errorModel, ControllerBase controller)
        {
            return statusCode switch
            {
                StatusCode.NotFound => controller.NotFound(errorModel),
                StatusCode.PermissionDenied => controller.StatusCode(StatusCodes.Status403Forbidden, errorModel),
                StatusCode.InvalidArgument => controller.StatusCode(StatusCodes.Status400BadRequest, errorModel),
                StatusCode.AlreadyExists => controller.StatusCode(StatusCodes.Status409Conflict, errorModel),
                StatusCode.Internal => controller.StatusCode(427, errorModel),
                _ => controller.StatusCode(StatusCodes.Status500InternalServerError, errorModel)
            };
        }
    }
}
