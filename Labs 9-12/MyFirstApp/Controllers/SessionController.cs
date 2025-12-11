using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyFirstApp.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SetSession()
        {
            // Store data in the session
            HttpContext.Session.SetString("UserEmail", "john.doe@example.com");
            HttpContext.Session.SetInt32("UserId", 1);

            return Content("Session data has been set.");
        }

        public IActionResult GetSession()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (string.IsNullOrEmpty(userEmail) || userId == null)
            {
                return Content("Session data not found.");
            }

            return Content($"User Email: {userEmail}, User ID: {userId}");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Content("All session data has been cleared.");
        }
    }
}
