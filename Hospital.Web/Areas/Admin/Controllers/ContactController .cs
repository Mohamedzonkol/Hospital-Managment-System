using Hospital.Services;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly IContactServiceses contactServices;

        public ContactController(IContactServiceses _contactServices)
        {
            contactServices = _contactServices;
        }
        public IActionResult Index(int PageNumber=1,int PageSize=10)
        {
            return View(contactServices.GetAll(PageNumber,PageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ContactViewModel contact = contactServices.getContactById(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            contactServices.Update(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            contactServices.Insetrt(vm);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ContactViewModel vm = contactServices.getContactById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Delete(ContactViewModel vm)
        {
            contactServices.Delete(vm.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ContactViewModel contact =contactServices.getContactById(id);

            return View(contact);
        }
        [HttpPost]
        public IActionResult Details(ContactViewModel vm)
        {
            contactServices.Update(vm);
            return RedirectToAction("Index");
        }
    }
}
