using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace scrum_Grupo2_website.html
{
    public partial class Doente : System.Web.UI.Page
    {
        Registo registo = new Registo();
        protected void Page_Load(object sender, EventArgs e)
        {
            label_valor.Text = "";
        }

        protected void btn_adicionar_valor_Click(object sender, EventArgs e)
        {
            if (registo.verificarNumero(TextBox_valor.Text))
            {

            }
            else
            {
                label_valor.Text = "Introduza um valor válido!";
            }
        }
    }
}