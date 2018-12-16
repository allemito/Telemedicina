using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Telemedicina_Website
{
    public partial class Medico : System.Web.UI.Page
    {
        // Ligação base dados oracle
        OracleConnection conexao = new OracleConnection("DATA SOURCE=25.15.145.193:1521/xe;PASSWORD=telemedicina;USER ID=Telemedicina_DataBase");
        OracleCommand comando = new OracleCommand();
        OracleDataReader dataReader;
        Registo registo = new Registo();
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            comando.Connection = conexao;
            panelDoente.Visible = false;
            panelDados.Visible = false;
            labelProcurar.Text = "";
            
            if(IsPostBack)
            {
                if (ViewState["user"] != null)
                {
                    username = (string)ViewState["user"];
                }
            }
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

                    //SE POSSIVEL COLOCAR TUDO NUMA SO QUERY
                    comando.CommandText = "SELECT Nome_Doente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
                    TextBox_Nome.Text = Convert.ToString(comando.ExecuteScalar());
                    comando.CommandText = "SELECT ID_Doente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
                    username = Convert.ToString(comando.ExecuteScalar());
                    ViewState["user"] = username;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "Select Valor_Glicemia, DATAHORA_ADD From (Select valor_glicemia, DATAHORA_ADD From DADOS_GLICEMIA Where ID_Doente = '"+username+"' and ROWNUM <= 7 order by DATAHORA_ADD desc) order by DATAHORA_ADD asc";
                    dataReader = comando.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ChartGlicemia.Series["Glicemia"].Points.AddXY(dataReader["DataHora_ADD"].ToString(), dataReader["Valor_Glicemia"].ToString());
                    }

                    //Verificar valores acima do normal
                    DateTime SeteDiasAntes = DateTime.Today.AddDays(-7);
                    string dataQuery = SeteDiasAntes.ToString("yyyy/MM/dd");
                    int numero_alertas = 0;
                    comando.CommandText = "Select Valor_Glicemia From DADOS_GLICEMIA Where ID_Doente = '"+username+"' and DATAHORA_ADD >= '"+dataQuery+"'";
                    dataReader = comando.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (Convert.ToUInt32(dataReader["Valor_Glicemia"]) > 160 || Convert.ToUInt32(dataReader["Valor_Glicemia"]) < 80)
                        {
                            numero_alertas++; 
                        }         
                    }
                    conexao.Close();
                    label_alertas.Text = "Atenção: Existem " + numero_alertas + " valor(es) nos últimos 7 dias que merece atenção médica!";
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

        protected void ButtonVer_Total_Click(object sender, EventArgs e)
        {
            panelDoente.Visible = false;
            panelDados.Visible = true;

            conexao.Open();
            comando.CommandText = "SELECT Nome_Doente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
            TextBoxnome.Text = Convert.ToString(comando.ExecuteScalar());

            DataSet data = new DataSet();
            comando.CommandText = "Select Datahora_add Data_Hora, Valor_Glicemia Glicemia, Insulina, Unidades_Administradas, Observacoes from Dados_Glicemia where Id_Doente = '"+username+"' order by DataHora_Add asc";
            comando.CommandType = CommandType.Text;

            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                dataAdapter.SelectCommand = comando;
                dataAdapter.Fill(data);

                GridViewGlicemia.DataSource = data;
                GridViewGlicemia.DataBind();
            }
            conexao.Close();

      
        }

        protected void ButtonParaTras_Click(object sender, EventArgs e)
        {
            panelDoente.Visible = true;
            panelDados.Visible = false;

            conexao.Open();
            comando.CommandText = "SELECT Nome_Doente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
            TextBox_Nome.Text = Convert.ToString(comando.ExecuteScalar());
            //comando.CommandText = "SELECT ID_Doente FROM Doente WHERE Numero_Utente = '" + TextBox_Procurar.Text + "'";
            //username = Convert.ToString(comando.ExecuteScalar());
            comando.ExecuteNonQuery();

            comando.CommandText = "Select Valor_Glicemia, DATAHORA_ADD From (Select valor_glicemia, DATAHORA_ADD From DADOS_GLICEMIA Where ID_Doente = '" + username + "' and ROWNUM <= 7 order by DATAHORA_ADD desc) order by DATAHORA_ADD asc";
            dataReader = comando.ExecuteReader();
            while (dataReader.Read())
            {
                ChartGlicemia.Series["Glicemia"].Points.AddXY(dataReader["DataHora_ADD"].ToString(), dataReader["Valor_Glicemia"].ToString());
            }

            //Verificar valores acima do normal
            DateTime SeteDiasAntes = DateTime.Today.AddDays(-7);
            string dataQuery = SeteDiasAntes.ToString("yyyy/MM/dd");
            int numero_alertas = 0;
            comando.CommandText = "Select Valor_Glicemia From DADOS_GLICEMIA Where ID_Doente = '" + username + "' and DATAHORA_ADD >= '" + dataQuery + "'";
            dataReader = comando.ExecuteReader();
            while (dataReader.Read())
            {
                if (Convert.ToUInt32(dataReader["Valor_Glicemia"]) > 160 || Convert.ToUInt32(dataReader["Valor_Glicemia"]) < 80)
                {
                    numero_alertas++;
                }
            }
            conexao.Close();
            label_alertas.Text = "Atenção: Existem " + numero_alertas + " valor(es) nos últimos 7 dias que merece atenção médica!";
        }
    }
}