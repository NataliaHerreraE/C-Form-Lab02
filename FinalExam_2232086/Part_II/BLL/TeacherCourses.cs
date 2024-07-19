using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_II.DAL;

namespace Part_II.BLL
{
    public class TeacherCourses
    {
        public int TeacherId { get; set; }
        public string CourseNumber { get; set; }

        public List<TeacherCourses> GetTeacherCourses(int teacherId) => TeacherCourseDB.GetTeacherCourses(teacherId);
        public void AssignCourseToTeacher(TeacherCourses tCourse) => TeacherCourseDB.AssignCourseToTeacher(tCourse);
        public void RemoveCourseFromTeacher(TeacherCourses tCourse) => TeacherCourseDB.RemoveCourseFromTeacher(tCourse);

    }
}
