using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
