using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class ClientAccount : System.Web.UI.Page
    {
        Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();
        string username = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_Account.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);

            username = service.getUsername();
            List<string> clientAccount = new List<string>();
            clientAccount = service.getClientDetails(username);
            if (name.Text == "")
            {
                name.Text = clientAccount[0];
            }
            if (surname.Text == "")
            {
                surname.Text = clientAccount[1];
            }
            if (email.Text == "")
            {
                email.Text = clientAccount[2];
            }
            if (day.Text == "")
            {
                day.Text = clientAccount[3].Substring(0, 2);
            }
            if (month.Text == "")
            {
                month.Text = clientAccount[3].Substring(3, 2);
            }
            if (year.Text == "")
            {
                year.Text = clientAccount[3].Substring(6);
            }
            if (other_details.Value == "")
            {
                other_details.Value = clientAccount[4];
            }
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + clientAccount[3] + "');", true);

        }

        protected void Update_Button1(object sender, EventArgs e)
        {
            username = service.getUsername();
            string nameClient = name.Text;
            string surnameClient = surname.Text;
            string address = email.Text;
            string birthday = day.Text + "/" + month.Text + "/" + year.Text;
            service.updateStuffClient(username, nameClient, surnameClient, address, birthday);
        }

        protected void Update_Button2(object sender, EventArgs e)
        {
            username = service.getUsername();
            string pass = service.getPassword(username);
            if(pass == current_pass.Text)
            {
                service.updatePassword(username, new_pass.Text);
            }
        }

        protected void Update_Button3(object sender, EventArgs e)
        {
            string details = other_details.Value;
            service.updateDetailsClient(username, details);

        }

        protected void Delete_Button(object sender, EventArgs e)
        {
            username = service.getUsername();
            service.deleteAccount(username);
            Response.Redirect("~/Home.aspx");
        }

        protected void Logout_Button(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}