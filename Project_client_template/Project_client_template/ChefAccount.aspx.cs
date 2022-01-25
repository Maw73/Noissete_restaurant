using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class ChefAccount : System.Web.UI.Page
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
            List<string> chefAccount = new List<string>();
            chefAccount = service.getChefDetails(username);
            if (name.Text == "")
            {
                name.Text = chefAccount[0];
            }
            if (surname.Text == "")
            {
                surname.Text = chefAccount[1];
            }
            if (day.Text == "")
            {
                day.Text = chefAccount[2].Substring(0, 2);
            }
            if (month.Text == "")
            {
                month.Text = chefAccount[2].Substring(3, 2);
            }
            if (year.Text == "")
            {
                year.Text = chefAccount[2].Substring(6);
            }
            if (other_details.Value == "")
            {
                other_details.Value = chefAccount[3];
            }
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + clientAccount[3] + "');", true);

        }

        protected void Update_Button1(object sender, EventArgs e)
        {
            username = service.getUsername();
            string nameChef = name.Text;
            string surnameChef = surname.Text;
            string birthday = day.Text + "/" + month.Text + "/" + year.Text;
            service.updateStuffChefs(username, nameChef, surnameChef, birthday);
        }

        protected void Update_Button2(object sender, EventArgs e)
        {
            username = service.getUsername();
            string pass = service.getPassword(username);
            if (pass == current_pass.Text)
            {
                service.updatePassword(username, new_pass.Text);
            }
        }

        protected void Update_Button3(object sender, EventArgs e)
        {
            username = service.getUsername();
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