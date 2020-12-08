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
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Default.aspx");
            if (!user.IsAdmin) Response.Redirect("Default.aspx");

            if (string.IsNullOrEmpty(Request.QueryString["id"])) Response.Redirect("Default.aspx");
            var isInt = int.TryParse(Request.QueryString["id"], out int id);
            if (!isInt) Response.Redirect("Default.aspx");

            var categoryBll = new CategoryBll();
            var brandBll = new BrandBll();
            var productBll = new ProductBll();

            var categories = categoryBll.GetCategories();
            var brands = brandBll.GetBrands();
            var product = productBll.GetProduct(id);

            if (categories is null || brands is null) Response.Redirect("Default.aspx");

            if (!IsPostBack)
            {
                productId.Text = product.Id.ToString();
                name.Text = product.Name;
                price.Text = product.Price.ToString();
                brand.SelectedValue = product.BrandId.ToString();
                category.SelectedValue = product.CategoryId.ToString();
                isAvailable.Checked = product.IsAvailable;

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
                productBll.EditProduct(productId.Text, name.Text, price.Text, isAvailable.Checked, brand.SelectedValue,
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