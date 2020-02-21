using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IEmployeesService
    {

        IEnumerable<EmployeeViewModel> GetAll();


        EmployeeViewModel GetById(int id);


        void Commit();


        void AddNew(EmployeeViewModel model);

        void Delete(int id);
    }
}