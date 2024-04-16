using EmployeeDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDataContext dataContext;

        public EmployeesController(EmployeeDataContext context)
        {
            dataContext = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Districts = dataContext.GetDistrict();
            ViewBag.Municipalities = new List<Municipality>(); 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees model)
        {
            if (ModelState.IsValid)
            {
                dataContext.CreateEmployees(model);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult List()
        {
            List<Employees> list = dataContext.GetEmployees();
            return View(list);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = dataContext.GetEmployee(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Employees model)
        {
            dataContext.updateEmployees(model);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            dataContext.DeleteEmployees(Id);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult GetMunicipalitiesByDistrict(int districtId)
        {
            var municipalities = dataContext.GetMunicipalitiesByDistrictId(districtId); 
            return Json(municipalities);
        }
    }
}





    