using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class ReservationClient : System.Web.UI.Page
    {
        Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();
        string global = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_reservationClient.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);
            global = service.getUsername();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> response = new List<string>();
            string user = service.getUsername();
            string loc = address.Items[address.SelectedIndex].Text;
            string location = loc.Substring(loc.IndexOf(':') + 2);
            string day = date.Text;
            string h = hours.Items[hours.SelectedIndex].Text;
            int hour = int.Parse(h.Substring(0, 1));

            address.EnableViewState = true;
            hours.EnableViewState = true;

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "*" + location + "*" + h + "*" + "');", true);
            
            chefs.Items.Clear();
            response = service.verifyAppointment(location, day, hour);
            if (response != null)
            {
                foreach (string chef in response)
                {
                    chefs.Items.Add(chef);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No chef available! Please choose another hour." + "');", true);
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> response = new List<string>();
            string user = service.getUsername();
            string loc = address.Items[address.SelectedIndex].Text;
            string location = loc.Substring(loc.IndexOf(':') + 2);
            string day = date.Text;
            string h = hours.Items[address.SelectedIndex].Text;
            int hour = int.Parse(h.Substring(0, 1));
            response = service.verifyAppointment(location, day, hour);

            int index = chefs.SelectedIndex;
            string nameChef = response[index];
            string[] nameall = nameChef.Split(' ');
            string name = nameall[0];
            string surname = nameall[1];

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + global + "');", true);
            service.createAppointment(user, location, day, hour, name, surname);
            Response.Redirect(Request.RawUrl);
        }

    }
}