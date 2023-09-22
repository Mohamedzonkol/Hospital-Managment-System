using Hospital.Services;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomController : Controller
    {
        private readonly IRoomServices roomServices;

        public RoomController(IRoomServices _roomServices)
        {
            roomServices = _roomServices;
        }
        public IActionResult Index(int PageNumber=1,int PageSize=10)
        {
            return View(roomServices.GetAll(PageNumber,PageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            RoomViewModel room = roomServices.getRoomById(id);
            return View(room);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            roomServices.Update(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            roomServices.Insetrt(vm);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            RoomViewModel vm = roomServices.getRoomById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Delete(RoomViewModel vm)
        {
            roomServices.Delete(vm.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            RoomViewModel hospetal = roomServices.getRoomById(id);

            return View(hospetal);
        }
        [HttpPost]
        public IActionResult Details(RoomViewModel vm)
        {
            roomServices.Update(vm);
            return RedirectToAction("Index");
        }
    }
}
