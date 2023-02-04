using Microsoft.AspNetCore.Mvc;

namespace ProvaTecnicaFox.api.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
