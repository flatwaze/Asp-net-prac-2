using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesService
    {
        public EmployeesClient(IConfiguration config) : base(config, "api/employees") { }

        public IEnumerable<EmployeeViewModel> GetAll() => Get<List<EmployeeViewModel>>(_ServiceAddress);

        public EmployeeViewModel GetById(int id) => Get<EmployeeViewModel>($"{_ServiceAddress}/{id}");

        public void AddNew(EmployeeViewModel Employee) => Post(_ServiceAddress, Employee);

        /*Отсутсвтует реализация в базовом интрефейсе
        public EmployeeViewModel Edit(int id, EmployeeViewModel Employee)
        {
            var response = Put($"{_ServiceAddress}/{id}", Employee);
            return response.Content.ReadAsAsync<EmployeeViewModel>().Result;
        }
        */

        public bool Delete(int id) => Delete($"{_ServiceAddress}/{id}").IsSuccessStatusCode;

        public void Commit() { }
    }
}
