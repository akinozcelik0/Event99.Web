using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Event99.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Admin, Individual")]

    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
