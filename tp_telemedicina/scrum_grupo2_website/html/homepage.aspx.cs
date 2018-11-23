using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace scrum_Grupo2_website
{
    public partial class homepage : System.Web.UI.Page
    {
        // Ligação base dados oracle
        OracleConnection conexao = new OracleConnection("DATA SOURCE=25.15.145.193:1521/xe;PASSWORD=scrumdatabase;USER ID=SCRUM_GRUPO2_DATABASE");
        OracleCommand comando = new OracleCommand();
        OracleDataReader dataReader;
        Registo registo = new Registo();

        protected void Page_Load(object sender, EventArgs e)
        {
            comando.Connection = conexao;
        }
    }
}