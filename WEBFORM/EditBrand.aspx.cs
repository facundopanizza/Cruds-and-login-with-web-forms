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
    public partial class EditBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Brands.aspx");
            if (!user.IsAdmin) Response.Redirect("Brands.aspx");

            if (Page.IsPostBack) return;

            if (string.IsNullOrEmpty(Request.QueryString["id"])) Response.Redirect("Brands.aspx");
            var isInt = int.TryParse(Request.QueryString["id"], out int id);
            if (!isInt) Response.Redirect("Brands.aspx");

            var brandBll = new BrandBll();
            var brand = brandBll.GetBrand(id);

            if (brand is null) Response.Redirect("Brands.aspx");

            brandId.Text = brand.Id.ToString();
            name.Text = brand.Name;
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            var brandBll = new BrandBll();

            var isInt = int.TryParse(brandId.Text, out int id);
            if(!isInt) Response.Redirect("Brands.aspx");

            try
            {
                brandBll.EditBrand(id, name.Text);
                Response.Redirect("Brands.aspx");
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }

        }
    }
}