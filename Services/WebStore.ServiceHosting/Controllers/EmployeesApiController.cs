using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesService
    {
        private readonly IEmployeesService _EmployeesService;
        public EmployeesApiController(IEmployeesService EmployeesService) => _EmployeesService = EmployeesService;

        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody] EmployeeViewModel model) => _EmployeesService.AddNew(model);

        [HttpGet, ActionName("Get")]
        public IEnumerable<EmployeeViewModel> GetAll() => _EmployeesService.GetAll();

        [HttpGet("{id}"), ActionName("Get")]
        public EmployeeViewModel GetById(int id) => _EmployeesService.GetById(id);

        [NonAction]
        public void Commit() => _EmployeesService.Commit();

        [HttpDelete("{id}")]
        public void Delete(int id) => _EmployeesService.Delete(id);


    }
}