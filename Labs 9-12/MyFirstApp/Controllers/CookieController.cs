using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MyFirstApp.Controllers
{
    public class CookieController : Controller
    {

        public IActionResult SetCookie()
        {
            Response.Cookies.Append(
                "UserName",
                "JohnDoe",
                new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(30),
                    HttpOnly = true,
                    IsEssential = true
                });

            return Content("Cookie has been set.");
        }


        public IActionResult GetCookie()
        {
            var userName = Request.Cookies["UserName"];

            if (string.IsNullOrEmpty(userName))
            {
                return Content("Cookie not found.");
            }

            return Content($"Cookie value: {userName}");
        }


        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("UserName");
            return Content("Cookie has been deleted.");
        }



        public IActionResult SetPreferences(string theme)
        {
            if (string.IsNullOrWhiteSpace(theme))
            {
                theme = "Default";
            }

            Response.Cookies.Append(
                "PreferredTheme",
                theme,
                new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true,
                    IsEssential = true
                });

            return Content($"Preferred theme '{theme}' has been saved.");
        }


        public IActionResult GetPreferences()
        {
            var theme = Request.Cookies["PreferredTheme"] ?? "Default";
            return Content($"Your preferred theme is: {theme}");
        }
    }
}

