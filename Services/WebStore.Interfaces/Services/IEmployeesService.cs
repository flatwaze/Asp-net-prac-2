using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Interfaces.Services
{
    public interface IEmployeesService
    {

        IEnumerable<EmployeeViewModel> GetAll();


        EmployeeViewModel GetById(int id);


        void Commit();

        void AddNew(EmployeeViewModel model);

        bool Delete(int id);
    }
}