using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortugolWebsite.Pages.Frontoffice
{
    public partial class Ide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Alterar o label título "lblMainTitle" da Masterpage
            Master.mainTitle = Resources.InfoMessages.titleIde;
        }
    }
}