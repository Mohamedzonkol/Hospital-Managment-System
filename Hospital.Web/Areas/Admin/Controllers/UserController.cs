using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IAppllecationUserServices userServices;

        public UserController(IAppllecationUserServices _userServices)
        {
            userServices = _userServices;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(userServices.GetAll(pageNumber, pageSize));
        } 
        public IActionResult AllDoctor(int pageNumber = 1, int pageSize = 10)
        {
            return View(userServices.GetAllDoctor(pageNumber, pageSize));
        }
    }
}
