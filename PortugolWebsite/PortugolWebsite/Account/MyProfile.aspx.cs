using PortugolWebsite.Code.BLL;
using PortugolWebsite.Code.CustomMembership;
using System;
using System.Data;
using System.Web.UI;

namespace PortugolWebsite.Account
{
    public partial class MyProfile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadIdioma();
                LoadRecordValues();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string nome = txtName.Text.Trim();
            string email = txtEmail.Text;
            int idiomaId = Convert.ToInt32(ddlIdioma.SelectedValue);

            BusinessUser.UpdateUser(nome, null, null, email, idiomaId, null, username);
           

        }

        private void LoadIdioma()
        {
            DataView idiomaView = BusinessIdioma.GetIdioma();
            ddlIdioma.DataSource = idiomaView;
            ddlIdioma.DataValueField = "IdLingua";
            ddlIdioma.DataTextField = "Lingua";
            ddlIdioma.DataBind();
        }

        private void LoadRecordValues()
        {
            string username = Convert.ToString(Session["username"]);

            DataView viewUser = BusinessUser.GetUser(null, username);

            txtUsername.Text = username;
            txtName.Text = Convert.ToString(viewUser[0]["Nome"]);
            txtEmail.Text = Convert.ToString(viewUser[0]["Email"]);
            ddlIdioma.SelectedValue = Convert.ToString(viewUser[0]["Lingua"]);
        }
    }
}