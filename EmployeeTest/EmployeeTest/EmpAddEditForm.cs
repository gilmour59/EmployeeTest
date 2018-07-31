using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeTest.Model;
using EmployeeTest.BusinessLayer;

namespace EmployeeTest
{
    public partial class EmpAddEditForm : Form
    {
        bool IsNew;

        public EmpAddEditForm(employee_info obj)
        {
            InitializeComponent();

            if (obj == null)
            {
                employeeinfoBindingSource.DataSource = new employee_info();
                IsNew = true;
            }
            else
            {
                employeeinfoBindingSource.DataSource = obj;
                IsNew = false;
            }
        }

        private void EmpAddEditForm_Load(object sender, EventArgs e)
        {

        }

        private void EmpAddEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {

                employee_info ei = employeeinfoBindingSource.Current as employee_info;

                if (string.IsNullOrEmpty(textBoxFirstName.Text))
                {
                    MessageBox.Show("Please Enter First Name!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxFirstName.Focus();
                    e.Cancel = true;
                    return;
                }

                if (string.IsNullOrEmpty(textBoxLastName.Text))
                {
                    MessageBox.Show("Please Enter Last Name!");
                    textBoxLastName.Focus();
                    e.Cancel = true;
                    return;
                }

                if ((string.IsNullOrEmpty(textBoxContactNumber.Text)) || (textBoxContactNumber.Text.Length != 11))
                {
                    MessageBox.Show("Please Enter Contact Number!");
                    textBoxContactNumber.Focus();
                    e.Cancel = true;
                    return;
                }

                if ((string.IsNullOrEmpty(dateTimePickerDOB.Text)))
                {
                    MessageBox.Show("Please Enter your Birth Date!");
                    dateTimePickerDOB.Focus();
                    e.Cancel = true;
                    return;
                }
                else
                {
                    ei.birthdate = Convert.ToDateTime(dateTimePickerDOB.Text);
                }

                if (IsNew)
                {
                    EmployeeInfoServices.Insert(ei);
                    MessageBox.Show("Added!");
                }
                else
                {
                    EmployeeInfoServices.Update(employeeinfoBindingSource.Current as employee_info);
                    MessageBox.Show("Saved!");
                }
            }
        }
    }
}
