using PortugolWebsite.Code.BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortugolWebsite.Pages.Forum
{
    public partial class threadView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.mainTitle = Resources.InfoMessages.titleForum;

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["TopicId"])) 
                    hiddenTopicId.Value = Request.QueryString["TopicId"];

                hyperLinkPostReply.NavigateUrl = "~/Pages/Forum/postReply.aspx?TopicId=" + hiddenTopicId.Value;

                LoadThreads();
            }
        }


        private void LoadThreads(string order = "Asc")
        {
            if (!string.IsNullOrEmpty(hiddenTopicId.Value))
            {
                int topic_Id = Convert.ToInt32(hiddenTopicId.Value);

                DataView dataview = BusinessForum.GetTopicThreads(topic_Id, order);

                dotForumDisplay.DataSource = dataview;
                dotForumDisplay.DataBind();
            }
        }

        protected void dotForumDisplay_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //Atualizar o index da paginação
            dotForumDisplay.CurrentPageIndex = e.NewPageIndex;

            //Carregar a GridView
            LoadThreads();
        }

        protected void sortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThreads(sortOrder.SelectedValue);

        }
    }
}