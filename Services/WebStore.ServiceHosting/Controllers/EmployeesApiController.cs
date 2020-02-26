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

        public void AddNew(EmployeeViewModel model) => _EmployeesService.AddNew(model);

        public void Commit() => _EmployeesService.Commit();

        public void Delete(int id) => _EmployeesService.Delete(id);

        public IEnumerable<EmployeeViewModel> GetAll() => _EmployeesService.GetAll();

        public EmployeeViewModel GetById(int id) => _EmployeesService.GetById(id);
    }
}