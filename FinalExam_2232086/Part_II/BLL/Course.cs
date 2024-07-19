using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_II.DAL;

namespace Part_II.BLL
{
    public class Course
    {
        public string CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public int Duration { get; set; }



        public List<Course> GetAllCourses() => CourseDB.GetAllCourses();
        public Course GetCourseByCourseNumber(string courseNumber) => CourseDB.GetCourseByCourseNumber(courseNumber);
        public List<Course> GetCoursesByTeacherId(int teacherId) => CourseDB.GetCoursesByTeacherId(teacherId);

    }
}
