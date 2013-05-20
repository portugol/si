using PortugolWebsite.Code.BLL;
using System;

namespace PortugolWebsite.Pages.Forum
{
    public partial class createTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void submitter_Click(object sender, EventArgs e)
        {
            try
            {
                //Inserir novo registo
                if (InsertRecord())
                    //Mostrar mensagem de sucesso
                    Response.Redirect("~/Pages/Forum/forum.aspx");
                else
                {
                    //Mostrar mensagem de erro
                    //TODO: Não faço ideia do que poderá acontecer
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
            
            string title = txtTitle.Text.Trim();
            string description = txtDescritpion.Text.Trim();
            int utilizador_id = 3; //TODO: Descomentar esta linha depois de implementada a segurança Convert.ToInt32(Session["user_id"]);

            if (BusinessForum.InsertTopic(title, description, utilizador_id))
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