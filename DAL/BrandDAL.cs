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
    public class BrandDal
    {
        public DataTable GetBrand(int id)
        {
            var oData = new Data();
            var parameter = new SqlParameter("@id", id);
            var vecParams = new SqlParameter[]
            {
                parameter
            };

            return oData.GetDataTable("SELECT * FROM Brand WHERE id = @id", vecParams);
        }

        public DataTable GetBrands()
        {
            var oData = new Data();

            return oData.GetDataTable("SELECT * FROM Brand", null);
        }

        public DataTable SearchBrands(string name)
        {
            var oData = new Data();

            var namePar = new SqlParameter("@name", $"%{name}%");
            var vecParams = new SqlParameter[]
            {
                namePar
            };

            return oData.GetDataTable("SELECT * FROM Brand WHERE Name LIKE isNull(@name, Name)", vecParams);
        }

        public int CreateBrand(string name)
        {
            var oData = new Data();

            var namePar = new SqlParameter("@name", name);
            var vecParams = new SqlParameter[]
            {
                namePar
            };

            return (int)oData.ExecuteWithoutResults("INSERT INTO Brand (Name) VALUES (@name)", vecParams);
        }

        public int EditBrand(int id, string name)
        {
            var oData = new Data();

            var idPar = new SqlParameter("@id", id);
            var namePar = new SqlParameter("@name", name);
            var vecParams = new SqlParameter[]
            {
                idPar, namePar
            };

            return (int)oData.ExecuteWithoutResults("" +
                                                    "UPDATE Brand SET name = @name WHERE Id = @id", vecParams);
        }

        public int DeleteBrand(int id)
        {
            var oData = new Data();
            var parameter = new SqlParameter("@id", id);
            var vecParams = new SqlParameter[]
            {
                parameter
            };

            return oData.ExecuteWithoutResults("DELETE Brand WHERE Id = @id", vecParams);
        }
    }
}
