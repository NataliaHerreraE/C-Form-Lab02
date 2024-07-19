using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_II.DAL;

namespace Part_II.BLL
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

       
        public List<Teacher> GetAllTeachers() => TeacherDB.GetAllTeachers();
        public Teacher GetTeacher(int teacherId) => TeacherDB.GetTeacher(teacherId);
    }
}
