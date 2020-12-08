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
    public class CategoryDal
    {
        public DataTable GetCategory(int id)
        {
            var oData = new Data();
            var parameter = new SqlParameter("@id", id);
            var vecParams = new SqlParameter[]
            {
                parameter
            };

            return oData.GetDataTable("SELECT * FROM Category WHERE id = @id", vecParams);
        }

        public DataTable GetCategories()
        {
            var oData = new Data();

            return oData.GetDataTable("SELECT * FROM Category", null);
        }

        public DataTable SearchCategories(string name)
        {
            var oData = new Data();

            var namePar = new SqlParameter("@name", $"%{name}%");
            var vecParams = new SqlParameter[]
            {
                namePar
            };

            return oData.GetDataTable("SELECT * FROM Category WHERE Name LIKE isNull(@name, Name)", vecParams);
        }

        public int CreateCategory(string name)
        {
            var oData = new Data();

            var namePar = new SqlParameter("@name", name);
            var vecParams = new SqlParameter[]
            {
                namePar
            };

            return (int)oData.ExecuteWithoutResults("INSERT INTO Category (Name) VALUES (@name)", vecParams);
        }

        public int EditCategory(int id, string name)
        {
            var oData = new Data();

            var idPar = new SqlParameter("@id", id);
            var namePar = new SqlParameter("@name", name);
            var vecParams = new SqlParameter[]
            {
                idPar, namePar
            };

            return (int)oData.ExecuteWithoutResults("UPDATE Category SET name = @name WHERE Id = @id", vecParams); }

        public int DeleteCategory(int id)
        {
            var oData = new Data();
            var parameter = new SqlParameter("@id", id);
            var vecParams = new SqlParameter[]
            {
                parameter
            };

            return oData.ExecuteWithoutResults("DELETE Category WHERE Id = @id", vecParams);
        }
    }
}
