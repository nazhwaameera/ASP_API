using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyWebFormApp.BLL.DTOs;

namespace SampleMVC.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                var userDtoSerialize = HttpContext.Session.GetString("user");
                var userDto = JsonSerializer.Deserialize<UserDTO>(userDtoSerialize);
                ViewBag.UserName = $"{userDto.FirstName} {userDto.LastName}";
            }

            base.OnActionExecuting(context);
        }
    }
}
