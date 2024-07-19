using Part_II.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Part_II.VALIDATION;
using Part_II.DAL;

namespace Part_II.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserId.Text.Trim();
            if (!Validator.IsValidId(username))
            {
                MessageBox.Show("Invalid User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserId.Clear();
                txtUserId.Focus();
                return;
            }
            string password = txtPassword.Text.Trim();
            if (!Validator.IsValidPassword(password))
            {
                MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }
            int userId = Convert.ToInt32(txtUserId.Text.Trim());
            User user = new User().GetUser(userId, password);
            if (user != null)
            {
               
                Teacher teacher = new Teacher().GetTeacher(user.UserId);
                if (teacher != null)
                {
                    MessageBox.Show("Welcome " + user.JobTitle + " " + teacher.FirstName + " " + teacher.LastName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
                    CourseRegistrationForm courseRegForm = new CourseRegistrationForm(teacher.TeacherId, user.JobTitle);

                    this.Hide();
                    courseRegForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Teacher doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid User ID or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserId.Clear();
                txtPassword.Clear();
                txtUserId.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this app? ", "Exit ", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
