using PortugolWebsite.Code.BLL;
using System;

namespace PortugolWebsite.Account
{
    public partial class RecoverPassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (BusinessUser.ResetPassword(txtUsername.Text.Trim()))
            {
                //TODO: Apresentar mensagem de sucesso ao utilizador
            }
            else
            {
                //TODO: Apresentar mensagem de erro ao utilizador
            }
        }
    }
}