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
    public class BrandBll
    {

        public Brand GetBrand(int id)
        {
            var brandDal = new BrandDal();
            var dt = brandDal.GetBrand(id);
            var brand = new Brand();

            if (dt.Rows.Count <= 0) return null;

            var dr = dt.Rows[0];

            brand.Id = int.Parse(dr["Id"].ToString());
            brand.Name = dr["Name"].ToString();

            return brand;
        }

        public List<Brand> GetBrands()
        {
            var brandDal = new BrandDal();
            var dt = brandDal.GetBrands();
            var brandsList = new List<Brand>();

            foreach (DataRow dr in dt.Rows)
            {
                var brand = new Brand()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                };

                brandsList.Add(brand);
            }

            return brandsList;
        }

        public List<Brand> SearchBrands(string name)
        {
            var brandDal = new BrandDal();
            var dt = brandDal.SearchBrands(name);
            var brandsList = new List<Brand>();

            foreach (DataRow dr in dt.Rows)
            {
                var brand = new Brand()
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                };

                brandsList.Add(brand);
            }

            return brandsList;
        }

        public int CreateBrand(string name)
        {
            ValidateName(name);

            var brandDal = new BrandDal();

            return brandDal.CreateBrand(name);
        }

        public int EditBrand(int id, string name)
        {
            ValidateName(name);

            var brandDal = new BrandDal();

            return brandDal.EditBrand(id, name);
        }

        public int DeleteBrand(int dni)
        {
            var brandDal = new BrandDal();

            return brandDal.DeleteBrand(dni);
        }

        private void ValidateName(string name)
        {
            if (name == "") throw new Exception("The field 'Name' is required.");
        }
    }
}
