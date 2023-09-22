using Hospital.Services;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]

    public class HospitalController : Controller
    {
        private readonly IHospitalServices hospitalServices;

        public HospitalController(IHospitalServices _hospitalServices)
        {
            hospitalServices = _hospitalServices;
        }
        public IActionResult Index(int pageNumber=1,int pageSize=10)
        {
            return View(hospitalServices.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
          HospetalViewModel hospetal=  hospitalServices.getById(id);
            return View(hospetal);
        }
        [HttpPost]
        public IActionResult Edit(HospetalViewModel vm)
        { 
            hospitalServices.Update(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospetalViewModel vm) 
        {
            hospitalServices.Insetrt(vm);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id) 
        { 
           HospetalViewModel vm = hospitalServices.getById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Delete(HospetalViewModel vm) 
        { 
           hospitalServices.Delete(vm.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            HospetalViewModel hospetal = hospitalServices.getById(id);

            return View(hospetal);
        }
        [HttpPost]
        public IActionResult Details(HospetalViewModel vm)
        {
            hospitalServices.Update(vm);
            return RedirectToAction("Index");
        }

    }
}
