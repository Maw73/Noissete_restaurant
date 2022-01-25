using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class Login : System.Web.UI.Page
    {
        Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_login.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string user = username.Text;
            string pass = password.Text;

            int response = service.verifyLogin(user, pass);

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "*" + global + "*" + "');", true);

            if (response == 1)
            {
                service.setUsername(user);
                Response.Redirect("HomeLogin.aspx");
            }
            else if (response == 2) {
                service.setUsername(user);
                Response.Redirect("HomeLoginChef.aspx");
            }
            else if (response == -1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "The password is incorrect." + "');", true);
            }
            else if (response == -2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "The username does not exist." + "');", true);
            }
        }
    }
}