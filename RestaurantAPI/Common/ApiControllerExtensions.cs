using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Common
{
    public static class ApiControllerExtensions
    {
        public static IActionResult Problem(this ControllerBase controller, List<Error> errors)
        {
            if (errors.Count == 0)
                return controller.Problem();

            var firstError = errors[0];
            var response = new ApiResponse(false, firstError.Description);

            return firstError.Type switch
            {
                ErrorType.NotFound => controller.NotFound(response),
                ErrorType.Unauthorized => controller.Unauthorized(response),
                ErrorType.Forbidden => controller.StatusCode(StatusCodes.Status403Forbidden, response),
                ErrorType.Conflict => controller.Conflict(response),
                ErrorType.Validation => controller.BadRequest(response),
                _ => controller.BadRequest(response)
            };
        }
    }
}
