using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITIES;

namespace BLL
{
    public class ProductBll
    {

        public Product GetProduct(int id)
        {
            var productDal = new ProductDal();
            var dt = productDal.GetProduct(id);
            var product = new Product();

            if (dt.Rows.Count <= 0) return null;

            var dr = dt.Rows[0];

            product.Id = int.Parse(dr["Id"].ToString());
            product.Name = dr["Name"].ToString();
            product.Price = double.Parse(dr["Price"].ToString());
            product.IsAvailable = bool.Parse(dr["IsAvailable"].ToString());
            product.BrandId = int.Parse(dr["BrandId"].ToString());
            product.CategoryId = int.Parse(dr["CategoryId"].ToString());

            return product;
        }

        public List<Product> GetProducts()
        {
            var studentDal = new ProductDal();
            var dt = studentDal.GetProducts();
            var productsList = new List<Product>();

            foreach (DataRow dr in dt.Rows)
            {
                var product = new Product()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Price = double.Parse(dr["Price"].ToString()),
                    IsAvailable = bool.Parse(dr["IsAvailable"].ToString()),
                    BrandId = int.Parse(dr["BrandId"].ToString()),
                    CategoryId = int.Parse(dr["CategoryId"].ToString()),
                };

                productsList.Add(product);
            }

            return productsList;
        }

        public List<Product> SearchProducts(string name)
        {
            var productDal = new ProductDal();
            var dt = productDal.SearchProducts(name);
            var productsList = new List<Product>();

            foreach (DataRow dr in dt.Rows)
            {
                var product = new Product
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Price = double.Parse(dr["Price"].ToString()),
                    IsAvailable = bool.Parse(dr["IsAvailable"].ToString()),
                    BrandId = int.Parse(dr["BrandId"].ToString()),
                    CategoryId = int.Parse(dr["CategoryId"].ToString()),
                };

                productsList.Add(product);
            }

            return productsList;
        }

        public int CreateProduct(string name, string price, bool isAvailable, string brandId, string categoryId)
        {
            var nameValidated = ValidateName(name);
            var priceValidated = ValidatePrice(price);
            var brandValidated = ValidateId(brandId, "Brand");
            var categoryValidated = ValidateId(categoryId, "Category");

            var productDal = new ProductDal();

            return productDal.CreateProduct(nameValidated, priceValidated, isAvailable, brandValidated, categoryValidated);
        }

        public int EditProduct(string id, string name, string price, bool isAvailable, string brandId, string categoryId)
        {
            var idValidated = ValidateId(id, "Id");
            var nameValidated = ValidateName(name);
            var priceValidated = ValidatePrice(price);
            var brandValidated = ValidateId(brandId, "Brand");
            var categoryValidated = ValidateId(categoryId, "Category");

            var productDal = new ProductDal();

            return productDal.EditProduct(idValidated, nameValidated, priceValidated, isAvailable, brandValidated, categoryValidated);
        }

        public int DeleteProduct(int dni)
        {
            var productDal = new ProductDal();

            return productDal.DeleteProduct(dni);
        }

        private string ValidateName(string name)
        {
            if (name == "") throw new Exception("The field 'Name' is required.");

            return name;
        }

        private double ValidatePrice(string price)
        {
            var isDouble = double.TryParse(price, out var convertedPrice);

            if (!isDouble) throw new Exception("The field 'Price' is required and must be a number.");

            return convertedPrice;
        }

        private int ValidateId(string id, string fieldName)
        {
            var isInt = int.TryParse(id, out var convertedId);

            if (!isInt) throw new Exception($"The field '{fieldName}' is required and must be a number.");

            return convertedId;

        }
    }
}
