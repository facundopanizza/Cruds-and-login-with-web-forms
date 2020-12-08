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
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User) Session["user"];

            if (!string.IsNullOrEmpty(Request.QueryString["Delete"]) && (User)Session["user"] != null && ((User)Session["user"]).IsAdmin)
            {
                var isInt = int.TryParse(Request.QueryString["Delete"], out int id);
                if (isInt)
                {
                    var categoryBll = new CategoryBll();
                    try
                    {
                        categoryBll.DeleteCategory(id);
                        Response.Redirect("Categories.aspx");
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
            var categoryBll = new CategoryBll();
            GridCategories.DataSource = categoryBll.GetCategories();
            GridCategories.DataBind();
        }

        protected void createCategory_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/CreateCategory");
        }

        protected void search_OnClick(object sender, EventArgs e)
        {
            var categoryBll = new CategoryBll();

            try
            {

                GridCategories.DataSource = categoryBll.SearchCategories(searchTerm.Text);
                GridCategories.DataBind();
            }
            catch (Exception exception)
            {
                error.InnerText = exception.Message;
            }
        }

        protected void orderByName_OnClick(object sender, EventArgs e)
        {
            var categoryBll = new CategoryBll();

            var orderName = (string)Session["orderName"];
            var categories = categoryBll.SearchCategories(searchTerm.Text);

            if (orderName == "desc")
            {
                orderName = "asc";
                categories = categories.OrderBy(p => p.Name).ToList();
            }
            else{
                orderName = "desc";
                categories = categories.OrderByDescending(p => p.Name).ToList();
            }

            Session["orderName"] = orderName;

            GridCategories.DataSource = categories;
            GridCategories.DataBind();
        }
    }
}