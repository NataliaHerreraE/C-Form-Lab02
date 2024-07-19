using Part_II.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_II.BLL
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }

        public User GetUser(int userId, string userPassword) => UserDB.GetUser(userId, userPassword);

    }
}
