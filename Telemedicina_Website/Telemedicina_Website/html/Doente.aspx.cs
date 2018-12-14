using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telemedicina_Website.html
{
    public partial class Doente : System.Web.UI.Page
    {
        OracleConnection conexao = new OracleConnection("DATA SOURCE=25.15.145.193:1521/xe;PASSWORD=telemedicina;USER ID=Telemedicina_DataBase");
        OracleCommand comando = new OracleCommand();
        OracleDataReader dataReader;
        Registo registo = new Registo();
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            comando.Connection = conexao;

            panelValores.Visible = false;
            TextBoxUnidades.Visible = false;
            labelInsolina.Visible = false;
            label_valor.Text = "";
            //TextBox_valor.Text = "";
            labelDiaHora.Text = "Data e Hora: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm");

            //Recebe o valor do numero de utente logado
            try
            {
                username = (string)(Session["username"]);
            }
            catch
            {

            }
        }

        protected void ButtonAddGlicemia_Click(object sender, EventArgs e)
        {
            panelValores.Visible = true;

            //Limpar todos os campos 
            TextBoxUnidades.Text = "";
            TextBox_Observacoes.Text = "";
            TextBox_valor.Text = "";
            DropDownListInsolina.ClearSelection();
        }

        protected void btn_adicionar_valor_Click(object sender, EventArgs e)
        {
            if(TextBox_valor.Text != "" & DropDownListInsolina.Text != "")
            {
                if (registo.verificarNumero(TextBox_valor.Text))
                {
                    if(DropDownListInsolina.Text == "Sim" & TextBoxUnidades.Text != "")
                    {
                        if(TextBox_Observacoes.Text != "")
                        {
                            panelValores.Visible = true;
                            labelInsolina.Visible = true;
                            TextBoxUnidades.Visible = true;
                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS
                                conexao.Open();
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina, Unidades_Administradas, Observacoes)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "', '" + TextBoxUnidades.Text + "', '" + TextBox_Observacoes.Text + "' )";
                                comando.ExecuteNonQuery();
                                conexao.Close();
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panelValores.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Acabou de inserir dados de glicemia, se pretender escolha a opção editar para proceder à sua alteração!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades.Text = "";
                            TextBox_Observacoes.Text = "";
                            TextBox_valor.Text = "";
                            DropDownListInsolina.ClearSelection();
                        }
                        else
                        {
                            panelValores.Visible = true;
                            labelInsolina.Visible = true;
                            TextBoxUnidades.Visible = true;

                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS ENVIA OBSERVAÇOES A VAZIO (=0)
                                conexao.Open();
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina, Unidades_Administradas, Observacoes)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "', '" + TextBoxUnidades.Text + "', '0' )";
                                comando.ExecuteNonQuery();
                                conexao.Close();
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panelValores.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Acabou de inserir dados de glicemia, se pretender escolha a opção editar para proceder à sua alteração!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades.Text = "";
                            TextBox_Observacoes.Text = "";
                            TextBox_valor.Text = "";
                            DropDownListInsolina.ClearSelection();
                        }
                    }
                    else if(DropDownListInsolina.Text == "Não")
                    {
                        if (TextBox_Observacoes.Text != "")
                        {
                            panelValores.Visible = true;

                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS
                                conexao.Open();
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina, Unidades_Administradas, Observacoes)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "', -1, '" + TextBox_Observacoes.Text + "' )";
                                comando.ExecuteNonQuery();
                                conexao.Close();
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panelValores.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Acabou de inserir dados de glicemia, se pretender escolha a opção editar para proceder à sua alteração!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades.Text = "";
                            TextBox_Observacoes.Text = "";
                            TextBox_valor.Text = "";
                            DropDownListInsolina.ClearSelection();
                        }
                        else
                        {
                            panelValores.Visible = true;

                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS ENVIA OBSERVAÇOES A VAZIO (=0)
                                conexao.Open();
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina, Unidades_Administradas, Observacoes)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "', -1, '0' )";
                                comando.ExecuteNonQuery();
                                conexao.Close();
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panelValores.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Acabou de inserir dados de glicemia, se pretender escolha a opção editar para proceder à sua alteração!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades.Text = "";
                            TextBox_Observacoes.Text = "";
                            TextBox_valor.Text = "";
                            DropDownListInsolina.ClearSelection();
                        }
                    }
                    else
                    {
                        panelValores.Visible = true;
                        labelInsolina.Visible = true;
                        TextBoxUnidades.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor, insira as Unidades de Insulina!');", true);
                    }
                }
                else
                {
                    panelValores.Visible = true;
                    label_valor.Text = "Introduza um valor válido!";
                }
            }
            else
            {
                panelValores.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor, preencha todos os campos!');", true);
            }
        }

        protected void DropDownListInsolina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownListInsolina.SelectedIndex == 1)
            {
                panelValores.Visible = true;
                TextBoxUnidades.Visible = true;
                labelInsolina.Visible = true;
            }
            else
            {
                panelValores.Visible = true;
                TextBoxUnidades.Visible = false;
                labelInsolina.Visible = false;
                TextBoxUnidades.Text = "";
            }
        }
    }
}