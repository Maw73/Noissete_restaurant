using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class ReservationChef : System.Web.UI.Page
    {
        static Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();
        protected static string username = service.getUsername();
        protected static List<int> ids = service.getIDsOfAppointmentsChef(username);
        protected List<string>[] reservations = new List<string>[ids.Count];
        protected List<string> locations = new List<string>();
        protected List<string> clientName = new List<string>();
        protected List<string> clientSurname = new List<string>();
        protected List<string> date = new List<string>();
        protected List<string> hour = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //IN WORKING
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_myAppointments.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);

            ids = service.getIDsOfAppointmentsChef(username);
            if (ids[0] != -1)
            {

                int no = ids.Count;

                for (int i = 0; i < no; i++)
                {
                    reservations[i] = service.getAppDetailsChef(ids[i]);
                }

                for (int i = 0; i < no; i++)
                {
                    locations.Add(reservations[i][0]);
                    clientName.Add(reservations[i][1]);
                    clientSurname.Add(reservations[i][2]);
                    date.Add(reservations[i][3]);
                    hour.Add(reservations[i][4] + ":00 pm");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No appointments." + "');", true);
            }

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please wait 10 seconds for the database to be updated." + "');", true);

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + reservations[0] + "*" + reservations[1] + "*" + reservations[2][0] + "');", true);
        }

    }
}