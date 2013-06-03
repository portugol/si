using PortugolWebsite.Code.BLL;
using System;
using System.Data;

namespace PortugolWebsite.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void setUserInfo(object sender, EventArgs e)
        {
            //Colocar em sessão o username
            Session["username"] = LoginControl.UserName;

            DataView dataView = BusinessUser.GetUser(null, LoginControl.UserName);

            //Verificar se existem registos a serem apresentados
            if (dataView != null && dataView.Count > 0)
            {
                DataRowView recordRow = dataView[0];
                //Colocar em sessão o id do user logado
                Session["user_id"] = Convert.ToInt32(recordRow["Id"]);
            }
            
        }
    }
}