using Part_II.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_II.DAL
{
    public class CourseDB
    {
        //get courses to the view
        public static List<Course> GetAllCourses()
        {
            List<Course> courseAvailableList = new List<Course>();
            SqlConnection connection = UtilityDB.GetDBConnection();
            String query = "SELECT * FROM Courses";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course();
                course.CourseNumber = reader["CourseNumber"].ToString();
                course.CourseTitle = reader["CourseTitle"].ToString();
                course.Duration = Convert.ToInt32(reader["Duration"]);
                courseAvailableList.Add(course);
            }
            connection.Close();
            return courseAvailableList;
        }

        //get course by course number
        public static Course GetCourseByCourseNumber(string courseNumber)
        {
            Course course = new Course();
            SqlConnection connection = UtilityDB.GetDBConnection();
            String query = "SELECT * FROM Courses WHERE CourseNumber = @CourseNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseNumber", courseNumber);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                course.CourseNumber = reader["CourseNumber"].ToString();
                course.CourseTitle = reader["CourseTitle"].ToString();
                course.Duration = Convert.ToInt32(reader["Duration"]);
            }
            else
            {
                course = null;
            }
            connection.Close();
            return course;
        }

        //get course by TeacherId
        public static List<Course> GetCoursesByTeacherId(int teacherId)
        {
            List<Course> courseList = new List<Course>();
            SqlConnection connection = UtilityDB.GetDBConnection();
            String query = "SELECT * FROM Courses WHERE CourseNumber IN (SELECT CourseNumber FROM TeacherCourses WHERE TeacherId = @TeacherId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TeacherId", teacherId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course();
                course.CourseNumber = reader["CourseNumber"].ToString();
                course.CourseTitle = reader["CourseTitle"].ToString();
                course.Duration = Convert.ToInt32(reader["Duration"]);
                courseList.Add(course);
            }
            connection.Close();
            return courseList;
        }
    }
}
