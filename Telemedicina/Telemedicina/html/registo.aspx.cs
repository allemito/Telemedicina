using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telemedicina
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btn_Registar_Click(object sender, EventArgs e)
        {
            String nome = txtbox_Nome.Text;
            String dataNascimento = txtbox_DataNascimento.Text;
            String morada = TextBox_Morada.Text;
            String codigoPostal = TextBox_CodigoPostal.Text;
           // int contacto = Convert.ToInt32(TextBox_Contacto.Text); //LEMBRAR TIRAR //
            String email = TextBox_Email.Text;
            String Password1 = TextBox_Password1.Text;
            String Password2 = TextBox_Password2.Text;
            
        }
    }
}