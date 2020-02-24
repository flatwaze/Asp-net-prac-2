using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }


        [Route("all")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_employeesService.GetAll());
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var employee = _employeesService.GetById(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }


        [HttpGet]
        [Route("edit/{id?}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeViewModel());

            EmployeeViewModel model = _employeesService.GetById(id.Value);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model.Age < 18 || model.Age > 100)
            {
                ModelState.AddModelError("Age", "Ошибка возраста!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id > 0) 
            {
                var dbItem = _employeesService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Position = model.Position;
            }
            else 
            {
                _employeesService.AddNew(model);
            }
            _employeesService.Commit(); 

            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _employeesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
