using System.Web.UI;

namespace PortugolWebsite.Code.Shared
{
    /// <summary>
    /// Funções públicas e estáticas que sejam uteis e transversais a toda a aplicação
    /// </summary>
    public static class SharedFunctions
    {
        /// <summary>
        /// Obter o controlo que causou o postback.
        /// Esta função é útil para efeitos de Debugging
        /// </summary>
        /// <param name="page">Página onde se quer encontrar o controlo que causou o postback</param>
        /// <returns>Controlo que causou o postback</returns>
        public static Control GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }
    }
}