using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITIES;

namespace BLL
{
    public class UserBll
    {
        public User Login(string username, string password)
        {
            var userDal = new UserDal();
            var dt = userDal.Login(username);
            var user = new User();

            if (dt.Rows.Count <= 0) throw new Exception("Incorrect 'Username'.");

            var dr = dt.Rows[0];

            user.Username = dr["Username"].ToString();
            user.Password = dr["Password"].ToString();
            user.IsAdmin = bool.Parse(dr["IsAdmin"].ToString());

            if (password != user.Password) throw new Exception("Incorrect 'Password'.");

            return user;
        }

        public int Register(string username, string password, string confirmPassword)
        {
            ValidateRequiredString(username, "Username");
            ValidateRequiredString(password, "Password");
            ValidateRequiredString(confirmPassword, "Confirm Password");

            if (password != confirmPassword) throw new Exception("The field Password and Confirm Password must be the same.");

            var userDal = new UserDal();

            return userDal.Register(username, password);
        }

        private string ValidateRequiredString(string fieldData, string field)
        {
            if (fieldData == "") throw new Exception($"The field {field} is required.");

            return fieldData;
        }
    }
}
