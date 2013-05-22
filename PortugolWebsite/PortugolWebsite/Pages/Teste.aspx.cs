using PortugolWebsite.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortugolWebsite.Pages
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadCapitulo();
        }

        private void LoadCapitulo()
        {
            //DataView dataview = BusinessCapitulo.GetCapitulo();

            //rbCapitulo.DataSource = dataview;
            //rbCapitulo.DataTextField = "Nome";
            //rbCapitulo.DataValueField = "Id";
            //rbCapitulo.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}