using Part_II.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_II.DAL
{
    public class TeacherCourseDB
    {
        //Search teacher course
        public static List<TeacherCourses> GetTeacherCourses(int teacherId)
        {
            List<TeacherCourses> teacherCourses = new List<TeacherCourses>();
            SqlConnection connection = UtilityDB.GetDBConnection();
            string selectStatement = "SELECT * FROM TeacherCourses " +
                                     "WHERE TeacherId = @TeacherId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@TeacherId", teacherId);
            SqlDataReader dr = selectCommand.ExecuteReader();
            while (dr.Read())
            {
                TeacherCourses teacherCourse = new TeacherCourses();
                teacherCourse.TeacherId = Convert.ToInt32(dr["TeacherId"]);
                teacherCourse.CourseNumber = dr["CourseNumber"].ToString();
                teacherCourses.Add(teacherCourse);
            }
            connection.Close();
            return teacherCourses;
        }

        //assign course to teacher
        public static void AssignCourseToTeacher(TeacherCourses tCourse)
        {
            SqlConnection connection = UtilityDB.GetDBConnection();
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = "INSERT INTO TeacherCourses (TeacherId, CourseNumber) " +
                                        "VALUES (@TeacherId, @CourseNumber)";
            insertCommand.Parameters.AddWithValue("@TeacherId", tCourse.TeacherId);
            insertCommand.Parameters.AddWithValue("@CourseNumber", tCourse.CourseNumber);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        //remove course from teacher
        public static void RemoveCourseFromTeacher(TeacherCourses tCourse)
        {
            SqlConnection connection = UtilityDB.GetDBConnection();
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = "DELETE FROM TeacherCourses " +
                                        "WHERE TeacherId = @TeacherId AND CourseNumber = @CourseNumber";
            insertCommand.Parameters.AddWithValue("@TeacherId", tCourse.TeacherId);
            insertCommand.Parameters.AddWithValue("@CourseNumber", tCourse.CourseNumber);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
