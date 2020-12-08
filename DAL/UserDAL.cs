using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;

namespace DAL
{
    public class UserDal
    {
        public DataTable Login(string username)
        {
            var oData = new Data();
            var usernameParameter = new SqlParameter("@username", username);
            var vecParams = new SqlParameter[]
            {
                usernameParameter
            };

            return oData.GetDataTable("SELECT * FROM Users WHERE Username = isNull(@username, Username)", vecParams);
        }

        public int Register(string username, string password)
        {
            var oData = new Data();

            var usernameSelect = new SqlParameter("@username", username);

            var usernamePar = new SqlParameter("@username", username);
            var passwordPar = new SqlParameter("@password", password);

            var selectParameters = new SqlParameter[]
            {
                usernameSelect,
            };

            var vecParams = new SqlParameter[]
            {
                usernamePar,
                passwordPar
            };

            var userExists = oData.GetDataTable("SELECT * FROM Users WHERE Username = isNull(@username, Username)", selectParameters).Rows.Count;

            if (userExists > 0) throw new Exception("An user with that Username already exists.");

            return (int)oData.ExecuteWithoutResults("INSERT INTO Users (Username, Password) VALUES (@username, @password)", vecParams);
        }
    }
}
