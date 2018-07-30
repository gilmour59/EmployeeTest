using EmployeeTest.BusinessLayer;
using EmployeeTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTest
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //using (dbemployeeEntities db = new dbemployeeEntities())
            //{
            //    db.Database.ExecuteSqlCommand("UPDATE employee_info SET lastname = 'SQLTEST' WHERE empID = 19");
            //}

            employeeinfoBindingSource.DataSource = EmployeeInfoServices.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (EmpAddEditForm frm = new EmpAddEditForm(null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    employeeinfoBindingSource.DataSource = EmployeeInfoServices.GetAll();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (employeeinfoBindingSource.Current == null)
            {
                return;
            }

            using (EmpAddEditForm frm = new EmpAddEditForm(employeeinfoBindingSource.Current as employee_info))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    employeeinfoBindingSource.DataSource = EmployeeInfoServices.GetAll();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (employeeinfoBindingSource.Current == null)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                EmployeeInfoServices.Delete(employeeinfoBindingSource.Current as employee_info);
                employeeinfoBindingSource.RemoveCurrent();
            }
        }
    }
}
