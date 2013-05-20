using PortugolWebsite.Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortugolWebsite.Pages.Forum
{
    public partial class postReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.mainTitle = Resources.InfoMessages.titleForum;

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["TopicId"]))
                    hiddenTopicId.Value = Request.QueryString["TopicId"];

                topicLink.NavigateUrl = "~/Pages/Forum/threadView.aspx?TopicId=" + hiddenTopicId.Value;

        
            }
        }

        protected void canceller_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Forum/threadView.aspx?TopicId=" + hiddenTopicId.Value);

        }

        protected void submitter_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar se estamos a inserir um novo registo
                if (string.IsNullOrEmpty(hiddenRecordID.Value.Trim()))
                {
                    //Inserir novo registo
                    if (InsertRecord())
                        //Mostrar mensagem de sucesso
                        Response.Redirect("~/Pages/Forum/threadView.aspx?TopicId=" + hiddenTopicId.Value);
                    else
                    {
                        //Mostrar mensagem de erro
                        //TODO: Não faço ideia do que poderá acontecer
                    }
                }
                else
                {
                    //Actualizar registo existente
                    if (UpdateRecord())
                        //Mostrar mensagem de sucesso
                        Response.Redirect("~/Pages/Forum/threadView.aspx?TopicId=" + hiddenTopicId.Value);
                    else
                    {
                        //Mostrar mensagem de erro
                        //TODO: Não faço ideia do que poderá acontecer
                    }

                }
            }
            catch (Exception ex)
            {
                //Mostrar mensagem de erro
                //TODO: Não faço ideia do que poderá acontecer
            }
        }

        private bool InsertRecord()
        {
            //Declarar e definir variáveis para inserção de registo
            int topic_Id = Convert.ToInt32(hiddenTopicId.Value);
            string subject = txtSubject.Text.Trim();
            string post = txtPost.Text.Trim();
            int utilizador_id = 3; //TODO: Descomentar esta linha depois de implementada a segurança Convert.ToInt32(Session["user_id"]);

            if (BusinessForum.InsertThread(topic_Id, subject, post, utilizador_id))
            {
                    return true;
            }
            else
            {//Houve um erro
                return false;
            }
        }

        private bool UpdateRecord()
        {
            //Declarar e definir variáveis para inserção de registo
            int thread_Id = Convert.ToInt32(hiddenRecordID.Value);
            string subject = txtSubject.Text.Trim();
            string post = txtPost.Text.Trim();


            if (BusinessForum.UpdateThread(thread_Id, subject, post))
            {
                return true;
            }
            else
            {//Houve um erro
                return false;
            }

        }

    }
}