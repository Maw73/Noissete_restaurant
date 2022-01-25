using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class Chefs : System.Web.UI.Page
    {
        static Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();
        protected static List<string> usernames = service.getAllUsernamesOfChefs();
        protected List<string>[] chefs = new List<string>[usernames.Count];
        protected List<string> nameChef = new List<string>();
        protected List<string> surnameChef = new List<string>();
        protected List<string> details = new List<string>();
        protected List<string> cuisine = new List<string>();
        protected List<string> location = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_chefs.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);

            int no = usernames.Count;

            for (int i = 0; i < no; i++)
            {
                chefs[i] = service.getChefDetails(usernames[i]);
            }
            for (int i = 0; i < no; i++)
            {
                nameChef.Add(chefs[i][0]);
                surnameChef.Add(chefs[i][1]);
                details.Add(chefs[i][3]);
                cuisine.Add(chefs[i][5]);
                location.Add(chefs[i][4]);
            }
            
        }
    }
} 
