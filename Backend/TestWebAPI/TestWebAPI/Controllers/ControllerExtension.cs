using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestWebAPI.Controllers
{
    public static class ControllerExtensions
    {
        public static Guid? GetCurrentLoginUserId(this ControllerBase controller)
        {
            if (controller.HttpContext.User.Identity is ClaimsIdentity identity)

            {
                var userIdString = identity?.FindFirst("UserId")?.Value;

                if (string.IsNullOrWhiteSpace(userIdString))
                    return null;

                var isUserIdValid = Guid.TryParse(userIdString, out Guid userId);

                if (!isUserIdValid)
                    return null;

                return userId;
            }
            else
            {
                return null;
            }
        }
    }
}
