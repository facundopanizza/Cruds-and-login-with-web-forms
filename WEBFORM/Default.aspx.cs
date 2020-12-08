using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ENTITIES;
using Exception = System.Exception;

namespace WEBFORM
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User) Session["user"];

            if (!string.IsNullOrEmpty(Request.QueryString["Delete"]) && (User)Session["user"] != null && ((User)Session["user"]).IsAdmin)
            {
                var isInt = int.TryParse(Request.QueryString["Delete"], out int id);
                if (isInt)
                {
                    var productBll = new ProductBll();
                    try
                    {
                        productBll.DeleteProduct(id);
                        Response.Redirect("Default.aspx");
                    }
                    catch (Exception exception)
                    {
                        error.InnerText = exception.Message;
                    }
                }
            }

            SeeGrid();
        }

        private void SeeGrid()
        {
            var productBll = new ProductBll();

            GridProducts.DataSource = productBll.GetProducts();
            GridProducts.DataBind();
        }

        protected void createProduct_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");
        }

        protected void search_OnClick(object sender, EventArgs e)
        {
            var productBll = new ProductBll();

            try
            {

                GridProducts.DataSource = productBll.SearchProducts(searchTerm.Text);
                GridProducts.DataBind();
            }
            catch (Exception exception)
            {
                error.InnerText = exception.Message;
            }
        }

        protected void orderByPrice_OnClick(object sender, EventArgs e)
        {
            var productBll = new ProductBll();

            var orderPrice = (string)Session["orderPrice"];
            var products = productBll.SearchProducts(searchTerm.Text);

            if (orderPrice == "desc")
            {
                orderPrice = "asc";
                products = products.OrderBy(p => p.Price).ToList();
            }
            else{
                orderPrice = "desc";
                products = products.OrderByDescending(p => p.Price).ToList();
            }

            Session["orderPrice"] = orderPrice;
            Session["orderName"] = null;

            GridProducts.DataSource = products;
            GridProducts.DataBind();
        }

        protected void orderByName_OnClick(object sender, EventArgs e)
        {
            var productBll = new ProductBll();

            var orderName = (string)Session["orderName"];
            var products = productBll.SearchProducts(searchTerm.Text);

            if (orderName == "desc")
            {
                orderName = "asc";
                products = products.OrderBy(p => p.Name).ToList();
            }
            else{
                orderName = "desc";
                products = products.OrderByDescending(p => p.Name).ToList();
            }

            Session["orderPrice"] = null;
            Session["orderName"] = orderName;

            GridProducts.DataSource = products;
            GridProducts.DataBind();
        }

        public string GetVisibility()
        {
            var user = (User) Session["user"];

            if (user != null && user.IsAdmin)
            {
                return "";
            }
            else
            {
                return "Hidden";
            }
        }
    }
}