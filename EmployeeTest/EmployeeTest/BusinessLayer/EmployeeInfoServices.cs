using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using EmployeeTest.DataLayer;
using EmployeeTest.Model;

namespace EmployeeTest.BusinessLayer
{
    public static class EmployeeInfoServices
    {
        static IEmployeeInfoRepository repository;

        static EmployeeInfoServices() {

            repository = new EmployeeInfoRepository();
        }

        public static IList<employee_info> GetAll() {

            return repository.GetAll();
        }

        public static employee_info GetById(int id) {

            return repository.GetById(id);
        }

        public static employee_info Insert(employee_info obj) {

            return repository.Insert(obj);
        }

        public static void Update(employee_info obj) {

            repository.Update(obj);
        }

        public static void Delete(employee_info obj) {

            repository.Delete(obj);
        }
    }
}
