using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ENTITIES;

namespace WEBFORM
{
    public partial class Brands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User) Session["user"];

            if (!string.IsNullOrEmpty(Request.QueryString["Delete"]) && (User)Session["user"] != null && ((User)Session["user"]).IsAdmin)
            {
                var isInt = int.TryParse(Request.QueryString["Delete"], out int id);
                if (isInt)
                {
                    var brandBll = new BrandBll();
                    try
                    {
                        brandBll.DeleteBrand(id);
                        Response.Redirect("Brands.aspx");
                    }
                    catch (Exception exception)
                    {
                        error.InnerText = exception.Message;
                    }
                }
            }

            RenderGrid();
        }

        private void RenderGrid()
        {
            var brandBll = new BrandBll();
            GridBrands.DataSource = brandBll.GetBrands();
            GridBrands.DataBind();
        }

        protected void createBrand_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/CreateBrand");
        }

        protected void search_OnClick(object sender, EventArgs e)
        {
            var brandBll = new BrandBll();

            try
            {

                GridBrands.DataSource = brandBll.SearchBrands(searchTerm.Text);
                GridBrands.DataBind();
            }
            catch (Exception exception)
            {
                error.InnerText = exception.Message;
            }
        }

        protected void orderByName_OnClick(object sender, EventArgs e)
        {
            var brandBll = new BrandBll();

            var orderName = (string)Session["orderName"];
            var brands = brandBll.SearchBrands(searchTerm.Text);

            if (orderName == "desc")
            {
                orderName = "asc";
                brands = brands.OrderBy(p => p.Name).ToList();
            }
            else{
                orderName = "desc";
                brands = brands.OrderByDescending(p => p.Name).ToList();
            }

            Session["orderName"] = orderName;

            GridBrands.DataSource = brands;
            GridBrands.DataBind();
        }
    }
}