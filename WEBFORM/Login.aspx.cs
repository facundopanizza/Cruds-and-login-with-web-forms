using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using WebGrease.Css;

namespace WEBFORM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string) Session["username"])) Response.Redirect("Default.aspx");
        }

        protected void button_OnClick(object sender, EventArgs e)
        {
            var userBll = new UserBll();

            try
            {
                var user = userBll.Login(username.Text, password.Text);
                Session["user"] = user;
                Response.Redirect("Default.aspx");
            }
            catch (Exception exception)
            {
                error.InnerText = exception.Message;
            }
        }
    }
}