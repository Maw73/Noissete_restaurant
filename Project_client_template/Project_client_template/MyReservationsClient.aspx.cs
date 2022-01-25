using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class MyReservationsClient : System.Web.UI.Page
    {
        static Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();
        protected static string user = service.getUsername();
        protected static List<int> ids = service.getAppointmentsClient(user);
        protected List<string>[] reservations = new List<string>[ids.Count];
        protected List<string> locations = new List<string>();
        protected List<string> chefName = new List<string>();
        protected List<string> chefSurname = new List<string>();
        protected List<string> date = new List<string>();
        protected List<string> hour = new List<string>();
        protected List<string> simpleHour = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_myAppointments.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);

            ids = service.getAppointmentsClient(user);
            int no = ids.Count;

                for (int i = 0; i < no; i++)
                {
                    reservations[i] = service.getDetailsOfAppointment(ids[i]);
                }
                
                for (int i = 0; i < no; i++)
                {
                    locations.Add(reservations[i][0]);
                    chefName.Add(reservations[i][1]);
                    chefSurname.Add(reservations[i][2]);
                    date.Add(reservations[i][3]);
                    hour.Add(reservations[i][4] + ":00 pm");
                    simpleHour.Add(reservations[i][4]);
                }

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please wait 10 seconds for the database to be updated." + "');", true);

            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + reservations[0] + "*" + reservations[1] + "*" + reservations[2][0] + "');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = service.getUsername();
            int index = int.Parse(textbox2.Value)-1;
            service.deleteAppointment(username, locations[index], date[index], int.Parse(simpleHour[index]), chefName[index], chefSurname[index]);
            Response.Redirect(Request.RawUrl);
        }
        
    }
}