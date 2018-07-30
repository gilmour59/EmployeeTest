using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using EmployeeTest.Model;

namespace EmployeeTest.DataLayer
{
    public interface IEmployeeInfoRepository
    {
        IList<employee_info> GetAll();
        employee_info GetById(int id);
        employee_info Insert(employee_info obj);
        void Update(employee_info obj);
        void Delete(employee_info obj);

    }
}
