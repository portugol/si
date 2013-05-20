using PortugolWebsite.Code.BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortugolWebsite.Pages.Forum
{
    public partial class forum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadForumGrid();
        }

        private void LoadForumGrid()
        {
            DataView dataview = BusinessForum.GetTopics();

            dotForumDisplay.DataSource = dataview;
            dotForumDisplay.DataBind();
        }

        protected void dotForumDisplay_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //Atualizar o index da paginação
            dotForumDisplay.CurrentPageIndex = e.NewPageIndex;

            //Carregar a GridView
            LoadForumGrid();

        }

        
    }
}