using Part_II.BLL;
using Part_II.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_II.GUI
{
    public partial class CourseRegistrationForm : Form
    {
        private int teacherId;
        private string jobTitle;
        private int userId;
        public CourseRegistrationForm(int teacherId, string jobTitle)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.jobTitle = jobTitle;
        }

        private void LoadTeacherInfo(int selectedTeacherId)
        {
            Teacher teacher = new Teacher().GetTeacher(selectedTeacherId);
            if (teacher != null)
            {
                comboBoxTeacherId.Text = Convert.ToString(teacher.TeacherId);
                txtFirstName.Text = teacher.FirstName;
                txtLastName.Text = teacher.LastName;
                txtEmail.Text = teacher.Email;
            }
        }
        private void LoadTeacherCourses(int selectedTeacherId)
        {
          
            listViewCourses.Items.Clear();
            List<Course> assignedCourses = new Course().GetCoursesByTeacherId(selectedTeacherId);
            foreach (Course course in assignedCourses)
            {
                ListViewItem item = new ListViewItem(course.CourseNumber);
                item.SubItems.Add(course.CourseTitle);
                item.SubItems.Add(course.Duration.ToString());
                listViewCourses.Items.Add(item);
            }
        }
        private void LoadAllTeachers()
        {
            List<Teacher> teachers = new Teacher().GetAllTeachers();
            comboBoxTeacherId.DisplayMember = "TeacherId"; 
            comboBoxTeacherId.ValueMember = "TeacherId";
            comboBoxTeacherId.DataSource = teachers;
        }
        private void LoadAllCourses()
        {
            List<Course> courses = new Course().GetAllCourses();
            comboBoxCourseNumber.DisplayMember = "CourseNumber";
            comboBoxCourseNumber.ValueMember = "CourseNumber";
            comboBoxCourseNumber.DataSource = courses;
        }
        private void CourseRegistrationForm_Load(object sender, EventArgs e)
        {
            LoadAllCourses();

            if (jobTitle == "Teacher")
            {
                LoadAllTeachers();
                comboBoxTeacherId.SelectedValue = teacherId;
                comboBoxTeacherId.Enabled = false;
                comboBoxCourseNumber.Enabled = false;
                LoadTeacherInfo(teacherId);
                LoadTeacherCourses(teacherId);
                btnAddCourse.Enabled = false;
                btnDeleteCourse.Enabled = false;
            }
            else if (jobTitle == "Program Coordinator")
            {
               
                comboBoxTeacherId.Enabled = true;
                comboBoxCourseNumber.Enabled = true;
                btnAddCourse.Enabled = true;
                btnDeleteCourse.Enabled = true;

                LoadAllTeachers();
            }

        }
        private void RefreshCoursesListView()
        {
            listViewCourses.Items.Clear();
            List<TeacherCourses> teacherCourses = new TeacherCourses().GetTeacherCourses(userId);

            foreach (TeacherCourses sCourse in teacherCourses)
            {
                Course course = new Course().GetCourseByCourseNumber(sCourse.CourseNumber);
                if (course != null)
                {
                    ListViewItem item = new ListViewItem(course.CourseNumber);
                    item.SubItems.Add(course.CourseTitle);
                    item.SubItems.Add(course.Duration.ToString());
                    listViewCourses.Items.Add(item);
                }
            }
        }
        private void comboBoxTeacherId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTeacherId.SelectedIndex != -1)
            {
                int selectedTeacherId = Convert.ToInt32(comboBoxTeacherId.SelectedValue);
                LoadTeacherInfo(selectedTeacherId);
                if (jobTitle == "Program Coordinator")
                {
                    LoadTeacherCourses(selectedTeacherId);
                }
            }
        }

        private void comboBoxCourseNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourseNumber.SelectedIndex != -1)
            {
                Course selectedCourse = comboBoxCourseNumber.SelectedItem as Course;
                if (selectedCourse != null)
                {
                    txtCourseTitle.Text = selectedCourse.CourseTitle;
                    txtDuration.Text = selectedCourse.Duration.ToString();
                }
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            List<TeacherCourses> studentCourses = new TeacherCourses().GetTeacherCourses(userId);
            if (studentCourses.Count < 4)
            {
                if (comboBoxCourseNumber.SelectedIndex != -1)
                {
                    string selectedCourseNumber = comboBoxCourseNumber.SelectedValue.ToString();
                    TeacherCourses tCourse = new TeacherCourses
                    {
                        TeacherId = Convert.ToInt32(comboBoxTeacherId.SelectedValue),
                        CourseNumber = selectedCourseNumber
                    };

                    new TeacherCourses().AssignCourseToTeacher(tCourse);
                    RefreshCoursesListView();
                    MessageBox.Show("Course added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a course to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You cannot add more than 4 courses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (comboBoxCourseNumber.SelectedIndex != -1)
            {
                string selectedCourseNumber = comboBoxCourseNumber.SelectedValue.ToString();
                TeacherCourses tCourse = new TeacherCourses
                {
                    TeacherId = userId,
                    CourseNumber = selectedCourseNumber
                };
                new TeacherCourses().RemoveCourseFromTeacher(tCourse);
                MessageBox.Show("Course deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCoursesListView();
            }
        }

        private void btnTeacherCourses_Click(object sender, EventArgs e)
        {
            listViewCourses.Items.Clear();
            LoadTeacherCourses(teacherId);
            List<TeacherCourses> teacherCourses = new TeacherCourses().GetTeacherCourses(userId);

            foreach (TeacherCourses tCourse in teacherCourses)
            {
                Course course = new Course().GetCourseByCourseNumber(tCourse.CourseNumber);

                if (course != null)
                {
                    ListViewItem item = new ListViewItem(course.CourseNumber);
                    item.SubItems.Add(course.CourseTitle);
                    item.SubItems.Add(course.Duration.ToString());
                    listViewCourses.Items.Add(item);
                }
            }
        }

        private void btnAllCourses_Click(object sender, EventArgs e)
        {
            listViewCourses.Items.Clear();
            List<Course> courses = new Course().GetAllCourses();
            foreach (Course course in courses)
            {
                ListViewItem item = new ListViewItem(course.CourseNumber);
                item.SubItems.Add(course.CourseTitle);
                item.SubItems.Add(course.Duration.ToString());
                listViewCourses.Items.Add(item);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this app? ", "Exit ", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {

                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

            }
        }
    }
}
