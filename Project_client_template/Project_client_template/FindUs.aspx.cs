using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_client_template
{
    public partial class FindUs : System.Web.UI.Page
    {
        Project_client_template.ServiceReference1.WebService1SoapClient service =
            new Project_client_template.ServiceReference1.WebService1SoapClient();
        protected List<string> loc = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink css = new System.Web.UI.HtmlControls.HtmlLink();
            css.Href = "~/Content/style_findus.css";
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            // css.Attributes["media"] = "all"; //add any attributes as needed
            Master.Page.Header.Controls.Add(css);
            loc = service.getAllLocations();
        }
    }
}