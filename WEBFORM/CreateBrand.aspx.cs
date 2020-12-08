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
    public partial class CreateBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Brands.aspx");
            if (!user.IsAdmin) Response.Redirect("Brands.aspx");
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            var brandBll = new BrandBll();

            try
            {
                brandBll.CreateBrand(name.Text);
                Response.Redirect("/brands");
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }

        }
    }
}