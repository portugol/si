using PortugolWebsite.Code.BLL;
using PortugolWebsite.Code.CustomMembership;
using PortugolWebsite.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortugolWebsite.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus userStatus = MembershipCreateStatus.Success;
            CustomMembershipProvider mProvider = (CustomMembershipProvider)System.Web.Security.Membership.Providers["CustomMembershipProvider"];

            //Atribuição dos valores a variáveis
            string nome = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            int tipoUtilizador = 2; //TODO: Qual o tipo de utilizador que se deve associar por defeito?

            CustomMembershipUser newUser = mProvider.CreateUser(nome, null, null, email, null, null, tipoUtilizador, username, password, out userStatus);
            //TODO: CreateUser dá erro porque a língua é obrigatória... tem sentido que a língua seja obrigatória?!!!
            switch (userStatus)
            {
                case MembershipCreateStatus.DuplicateEmail:
                    lblDuplicateEmail.Visible = true;
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    lblDuplicateUserName.Visible = true;
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    lblInvalidEmail.Visible = true;
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    lblInvalidPassword.Visible = true;
                    break;
                case MembershipCreateStatus.ProviderError:
                    lblProviderError.Visible = true;
                    break;
                case MembershipCreateStatus.Success:
                    Response.Redirect("~/Account/RegisterSuccess.aspx");
                    break;
            }
        }
    }
}