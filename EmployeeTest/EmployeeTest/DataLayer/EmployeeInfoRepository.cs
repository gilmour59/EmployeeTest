using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using EmployeeTest.Model;

namespace EmployeeTest.DataLayer
{
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        public void Delete(employee_info obj)
        {
            using (dbemployeeEntities db = new dbemployeeEntities()) {

                db.employee_info.Attach(obj);
                db.employee_info.Remove(obj);
                db.SaveChanges();
            }
        }

        public IList<employee_info> GetAll()
        {
            using (dbemployeeEntities db = new dbemployeeEntities())
            {
                return db.employee_info.ToList();
            }
        }

        public employee_info GetById(int id)
        {
            using (dbemployeeEntities db = new dbemployeeEntities())
            {
                return db.employee_info.Find(id);
            }
        }

        public employee_info Insert(employee_info obj)
        {
            using (dbemployeeEntities db = new dbemployeeEntities())
            {
                db.employee_info.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(employee_info obj)
        {
            using (dbemployeeEntities db = new dbemployeeEntities())
            {
                db.employee_info.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
