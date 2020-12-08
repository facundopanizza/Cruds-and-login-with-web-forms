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
    public class ProductDal
    {
        public DataTable GetProduct(int id)
        {
            var oData = new Data();
            var parameter = new SqlParameter("@id", id);
            var vecParams = new SqlParameter[]
            {
                parameter
            };

            return oData.GetDataTable("SELECT * FROM Product WHERE id = @id", vecParams);
        }

        public DataTable GetProducts()
        {
            var oData = new Data();

            return oData.GetDataTable("SELECT * FROM Product", null);
        }

        public DataTable SearchProducts(string name)
        {
            var oData = new Data();

            var namePar = new SqlParameter("@name", $"%{name}%");
            var vecParams = new SqlParameter[]
            {
                namePar
            };

            return oData.GetDataTable("SELECT * FROM Product WHERE Name LIKE @name", vecParams);
        }

        public int CreateProduct(string name, double price, bool isAvailable, int brandId, int categoryId)
        {
            var oData = new Data();

            var namePar = new SqlParameter("@name", name);
            var pricePar = new SqlParameter("@price", price);
            var isAvailablePar = new SqlParameter("@isAvailable", isAvailable);
            var brandIdPar = new SqlParameter("@brandId", brandId);
            var categoryIdPar = new SqlParameter("@categoryId", categoryId);
            var vecParams = new SqlParameter[]
            {
                namePar, pricePar, isAvailablePar, brandIdPar, categoryIdPar
            };

            return (int)oData.ExecuteWithoutResults("INSERT INTO Product (Name, Price, IsAvailable, BrandId, CategoryId) VALUES (@name, @price, @isAvailable, @brandId, @categoryId)", vecParams);
        }

        public int EditProduct(int id, string name, double price, bool isAvailable, int brandId, int categoryId)
        {
            var oData = new Data();

            var idPar = new SqlParameter("@id", id);
            var namePar = new SqlParameter("@name", name);
            var pricePar = new SqlParameter("@price", price);
            var isAvailablePar = new SqlParameter("@isAvailable", isAvailable);
            var brandIdPar = new SqlParameter("@brandId", brandId);
            var categoryIdPar = new SqlParameter("@categoryId", categoryId);
            var vecParams = new SqlParameter[]
            {
                idPar, namePar, pricePar, isAvailablePar, brandIdPar, categoryIdPar
            };

            return (int)oData.ExecuteWithoutResults("" +
                                                    "UPDATE Product SET " +
                                                    "name = @name, " +
                                                    "price = @price, " +
                                                    "IsAvailable = @isAvailable, " +
                                                    "BrandId = @brandId, " +
                                                    "CategoryId = @categoryId " +
                                                    "WHERE Id = @id", vecParams);
        }

        public int DeleteProduct(int id)
        {
            var oData = new Data();
            var parameter = new SqlParameter("@id", id);
            var vecParams = new SqlParameter[]
            {
                parameter
            };

            return oData.ExecuteWithoutResults("DELETE Product WHERE Id = @id", vecParams);
        }
    }
}
