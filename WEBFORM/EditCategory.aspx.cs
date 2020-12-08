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
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Categories.aspx");
            if (!user.IsAdmin) Response.Redirect("Categories.aspx");

            if (Page.IsPostBack) return;

            if (string.IsNullOrEmpty(Request.QueryString["id"])) Response.Redirect("Categories.aspx");
            var isInt = int.TryParse(Request.QueryString["id"], out int id);
            if (!isInt) Response.Redirect("Categories.aspx");

            var categoryBll = new CategoryBll();
            var category = categoryBll.GetCategory(id);

            if (category is null) Response.Redirect("Categories.aspx");

            categoryId.Text = category.Id.ToString();
            name.Text = category.Name;
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            var categoryBll = new CategoryBll();

            var isInt = int.TryParse(categoryId.Text, out int id);
            if(!isInt) Response.Redirect("Categories.aspx");

            try
            {
                categoryBll.EditCategory(id, name.Text);
                Response.Redirect("Categories.aspx");
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }

        }
    }
}