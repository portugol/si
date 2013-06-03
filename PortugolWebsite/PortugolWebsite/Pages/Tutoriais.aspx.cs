using System;

namespace PortugolWebsite.Pages.Frontoffice
{
    public partial class Tutoriais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Alterar o label título "lblMainTitle" da Masterpage
            Master.mainTitle = Resources.InfoMessages.titleTutorials;
        }
    }
}