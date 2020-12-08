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
    public partial class CreateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Default.aspx");
            if (!user.IsAdmin) Response.Redirect("Default.aspx");

            var categoryBll = new CategoryBll();
            var brandBll = new BrandBll();

            var categories = categoryBll.GetCategories();
            var brands = brandBll.GetBrands();

            if (categories is null || brands is null) Response.Redirect("Default.aspx");

            if (!IsPostBack)
            {
                brand.DataSource = brands;
                brand.DataBind();

                category.DataSource = categories;
                category.DataBind();
            }
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            var productBll = new ProductBll();

            try
            {
                productBll.CreateProduct(name.Text, price.Text, isAvailable.Checked, brand.SelectedValue,
                    category.SelectedValue);
                Response.Redirect("Default.aspx");
            }
            catch (Exception exception)
            {
                error.InnerText = exception.Message;
            }
        }
    }
}