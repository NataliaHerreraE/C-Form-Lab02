using Part_II.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_II.DAL
{
    public class TeacherDB
    {

        public static Teacher GetTeacher(int teacherId)
        {
            Teacher teacher = new Teacher();
            SqlConnection connection = UtilityDB.GetDBConnection();
            string selectStatement = "SELECT * FROM Teachers " +
                                     "WHERE TeacherId = @TeacherId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@TeacherId", teacherId);
            SqlDataReader dr = selectCommand.ExecuteReader();
            if (dr.Read())
            {
                teacher.TeacherId = Convert.ToInt32(dr["TeacherId"]);
                teacher.FirstName = dr["FirstName"].ToString();
                teacher.LastName = dr["LastName"].ToString();
                teacher.Email = dr["Email"].ToString();
            }
            else
            {
                teacher = null;
            }
            connection.Close();
            return teacher;
        }

        public static List<Teacher> GetAllTeachers()
        {
            List<Teacher> teacherList = new List<Teacher>();
            SqlConnection connection = UtilityDB.GetDBConnection();
            string selectStatement = "SELECT * FROM Teachers";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataReader dr = selectCommand.ExecuteReader();
            while (dr.Read())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherId = Convert.ToInt32(dr["TeacherId"]);
                teacher.FirstName = dr["FirstName"].ToString();
                teacher.LastName = dr["LastName"].ToString();
                teacher.Email = dr["Email"].ToString();
                teacherList.Add(teacher);
            }
            connection.Close();
            return teacherList;
        }
    }
}
