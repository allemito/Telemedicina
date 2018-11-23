using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace scrum_Grupo2_website
{
    public partial class Medico : System.Web.UI.Page
    {
        // Ligação base dados oracle
        OracleConnection conexao = new OracleConnection("DATA SOURCE=25.15.145.193:1521/xe;PASSWORD=telemedicina;USER ID=Telemedicina_DataBase");
        OracleCommand comando = new OracleCommand();
        OracleDataReader dataReader;
        Registo registo = new Registo();

        protected void Page_Load(object sender, EventArgs e)
        {
            comando.Connection = conexao;
            panelDoente.Visible = false;
            labelProcurar.Text = "";
        }

        protected void ButtonProcurar_Click(object sender, EventArgs e)
        {
            if (registo.verificarNumero(TextBox_Procurar.Text) == true)
            {
                //Executar Query de procura
                conexao.Open();
                comando.CommandText = "SELECT Numero_Utente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
                comando.ExecuteNonQuery();
                string IdProcurarDoente = Convert.ToString(comando.ExecuteScalar());

                if (TextBox_Procurar.Text == IdProcurarDoente && TextBox_Procurar.Text != "")
                {
                    panelDoente.Visible = true;

                    comando.CommandText = "SELECT Nome_Doente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
                    TextBox_Nome.Text = Convert.ToString(comando.ExecuteScalar());
                    comando.ExecuteNonQuery();
                    conexao.Close();
                }
                else
                {
                    labelProcurar.Text = "Não encontrado!";
                }
            }
            else
            {
                labelProcurar.Text = "Introduza um número válido!";
            }
        }
    }
}