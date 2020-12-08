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
    public partial class CreateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Categories.aspx");
            if (!user.IsAdmin) Response.Redirect("Categories.aspx");
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            var categoryBll = new CategoryBll();

            try
            {
                categoryBll.CreateCategory(name.Text);
                Response.Redirect("/categories");
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }

        }
    }
}