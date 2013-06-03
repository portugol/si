using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Alterar o label título "lblMainTitle" da Masterpage
        Master.mainTitle = Resources.InfoMessages.titleBackoffice;
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}
