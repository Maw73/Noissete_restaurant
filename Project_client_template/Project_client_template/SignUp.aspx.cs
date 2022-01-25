using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class SignUp : System.Web.UI.Page
    {
        Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_form.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            string birthday = day.Text + "/" + month.Text + "/" + year.Text;
            string firstName = name.Text;
            string lastName = surname.Text;
            string email = address.Text;
            string details = other_details.Value;
            
            string message = service.insertClient(user, pass, firstName, lastName, email, birthday, details);
            Response.Redirect("~/Login.aspx");
        }
    }
}