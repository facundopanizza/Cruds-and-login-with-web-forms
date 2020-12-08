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
    public class CategoryBll
    {

        public Category GetCategory(int id)
        {
            var categoryDal = new CategoryDal();
            var dt = categoryDal.GetCategory(id);
            var category = new Category();

            if (dt.Rows.Count <= 0) return null;

            var dr = dt.Rows[0];

            category.Id = int.Parse(dr["Id"].ToString());
            category.Name = dr["Name"].ToString();

            return category;
        }

        public List<Category> GetCategories()
        {
            var categoryDal = new CategoryDal();
            var dt = categoryDal.GetCategories();
            var categoriesList = new List<Category>();

            foreach (DataRow dr in dt.Rows)
            {
                var category = new Category()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                };

                categoriesList.Add(category);
            }

            return categoriesList;
        }

        public List<Category> SearchCategories(string name)
        {
            var categoryDal = new CategoryDal();
            var dt = categoryDal.SearchCategories(name);
            var categoriesList = new List<Category>();

            foreach (DataRow dr in dt.Rows)
            {
                var category = new Category()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                };

                categoriesList.Add(category);
            }

            return categoriesList;
        }

        public int CreateCategory(string name)
        {
            ValidateName(name);

            var categoryDal = new CategoryDal();

            return categoryDal.CreateCategory(name);
        }

        public int EditCategory(int id, string name)
        {
            ValidateName(name);

            var categoryDal = new CategoryDal();

            return categoryDal.EditCategory(id, name);
        }

        public int DeleteCategory(int dni)
        {
            var categoryDal = new CategoryDal();

            return categoryDal.DeleteCategory(dni);
        }

        private void ValidateName(string name)
        {
            if (name == "") throw new Exception("The field 'Name' is required.");
        }
    }
}
