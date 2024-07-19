using Part_II.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_II.DAL
{
    public class UserDB
    {
        //user check login
        public static User GetUser(int userId, string userPassword)
        {
            SqlConnection connection = UtilityDB.GetDBConnection();
            string selectStatement = "SELECT UserID, Password, JobTitle FROM Users WHERE UserID = @UserID AND Password = @Password";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@UserID", userId);
            selectCommand.Parameters.AddWithValue("@Password", userPassword);
            User user = null;

            SqlDataReader dr = selectCommand.ExecuteReader();
            if (dr.Read())
            {
                user = new User
                {
                    UserId = Convert.ToInt32(dr["UserID"]),
                    JobTitle = dr["JobTitle"].ToString() 
                };
            }
            connection.Close();
            return user;
        }

    }
}
