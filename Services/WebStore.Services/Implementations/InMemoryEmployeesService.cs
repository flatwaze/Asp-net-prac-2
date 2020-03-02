using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.Services.Implementations
{
    public class InMemoryEmployeesService : IEmployeesService
    {
        private readonly List<EmployeeViewModel> _employees;

        public InMemoryEmployeesService()
        {
            _employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    FirstName = "Иван",
                    SurName = "Иванов",
                    Patronymic = "Иванович",
                    Age = 22
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    FirstName = "Владислав",
                    SurName = "Петров",
                    Patronymic = "Иванович",
                    Age = 35
                }
            };
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _employees;
        }

        public EmployeeViewModel GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Commit()
        {
        }

        public void AddNew(EmployeeViewModel model)
        {
            model.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(model);
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
                return true;
            }
            return false;
        }
    }
}