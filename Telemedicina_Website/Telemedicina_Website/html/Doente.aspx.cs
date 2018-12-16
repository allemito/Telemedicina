using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
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
        int guardarGlicemia;

        protected void Page_Load(object sender, EventArgs e)
        {
            comando.Connection = conexao;
            panel_editar_valor.Visible = false;
            Panel_com_dois_botoes.Visible = false;
            panelValores.Visible = false;
            TextBoxUnidades.Visible = false;
            labelInsolina.Visible = false;
            labelinsulina_Editar.Visible = false;
            TextBoxUnidades_Editar.Visible = false;
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

            if(IsPostBack)
            {
                if (ViewState["glicemia"] != null)
                {
                    guardarGlicemia = (int)ViewState["glicemia"];
                }
            }
        }

        protected void ButtonAddGlicemia_Click(object sender, EventArgs e)
        {
            Panel_com_dois_botoes.Visible = true;

            //Limpar todos os campos 
            TextBoxUnidades.Text = "";
            TextBox_Observacoes.Text = "";
            TextBox_valor.Text = "";
            DropDownListInsolina.ClearSelection();
            guardarGlicemia = 0;
            ViewState["glicemia"] = guardarGlicemia;


            conexao.Open();
            DataSet data = new DataSet();
            comando.CommandText = "Select Datahora_add Data_Hora, Valor_Glicemia Glicemia, Insulina, Unidades_Administradas, Observacoes from Dados_Glicemia where Id_Doente = '" + username + "' order by Datahora_add asc";
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

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (Convert.ToInt32(TextBox_valor.Text) > 160 || Convert.ToInt32(TextBox_valor.Text) < 80)
                                {
                                    registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                }
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
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina, Unidades_Administradas)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "', '" + TextBoxUnidades.Text + "')";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (Convert.ToInt32(TextBox_valor.Text) > 160 || Convert.ToInt32(TextBox_valor.Text) < 80)
                                {
                                    registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                }
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
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina, Observacoes)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "', '" + TextBox_Observacoes.Text + "' )";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (Convert.ToInt32(TextBox_valor.Text) > 160 || Convert.ToInt32(TextBox_valor.Text) < 80)
                                {
                                    registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                }
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
                                comando.CommandText = "INSERT INTO DADOS_GLICEMIA(ID_Doente, DATAHORA_ADD, Valor_Glicemia, Insulina)VALUES('" + username + "', TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','YYYY-MM-DD HH24:MI'), '" + TextBox_valor.Text + "', '" + DropDownListInsolina.Text + "')";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (Convert.ToInt32(TextBox_valor.Text) > 160 || Convert.ToInt32(TextBox_valor.Text) < 80)
                                {
                                    registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                }
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
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor, preencha todos os campos obrigatorios!');", true);
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

        protected void ButtonAdicionar_Click(object sender, EventArgs e)
        {
            panelValores.Visible = true;
            panel_editar_valor.Visible = false;
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            panel_editar_valor.Visible = true;
            panelValores.Visible = false;
            string insulina;
            try
            {
                conexao.Open();
                comando.CommandText = "Select DataHora_Add From DADOS_GLICEMIA where id_doente = '" + username + "' and ROWNUM = 1 order by DATAHORA_ADD desc";
                labelHora_Editar.Text = Convert.ToString(comando.ExecuteScalar()); //Hora
                comando.CommandText = "Select Valor_Glicemia From DADOS_GLICEMIA where id_doente = '" + username + "' and ROWNUM = 1 order by DATAHORA_ADD desc";
                guardarGlicemia = Convert.ToInt32(comando.ExecuteScalar()); //Glicemia
                ViewState["glicemia"] = guardarGlicemia;
                TextBoxGlicemia_Editar.Text = guardarGlicemia.ToString();
                TextBoxGlicemia_Editar.Text = Convert.ToString(comando.ExecuteScalar()); //Glicemia
                comando.CommandText = "Select Insulina From DADOS_GLICEMIA where id_doente = '" + username + "' and ROWNUM = 1 order by DATAHORA_ADD desc";
                insulina = Convert.ToString(comando.ExecuteScalar()); //insulina
                comando.CommandText = "Select Observacoes From DADOS_GLICEMIA where id_doente = '" + username + "' and ROWNUM = 1 order by DATAHORA_ADD desc";
                TextBoxObservacoes_Editar.Text = Convert.ToString(comando.ExecuteScalar()); //Observaçoes

                if (insulina == "Sim")
                {
                    DropDownListInsolina_Editar.Text = insulina;
                    comando.CommandText = "Select Unidades_Administradas From DADOS_GLICEMIA where id_doente = '" + username + "' and ROWNUM = 1 order by DATAHORA_ADD desc";
                    TextBoxUnidades_Editar.Text = Convert.ToString(comando.ExecuteScalar()); //Unidades
                    TextBoxUnidades_Editar.Visible = true;
                    labelinsulina_Editar.Visible = true;
                }
                else
                {
                    DropDownListInsolina_Editar.Text = insulina;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                panel_editar_valor.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Não existe nenhum valor de glicemia inserido!');", true);
            }
        }

        protected void DropDownListInsolina_Editar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListInsolina_Editar.SelectedIndex == 1)
            {
                panel_editar_valor.Visible = true;
                labelinsulina_Editar.Visible = true;
                TextBoxUnidades_Editar.Visible = true;
            }
            else
            {
                panel_editar_valor.Visible = true;
                labelinsulina_Editar.Visible = false;
                TextBoxUnidades_Editar.Visible = false;
                TextBoxUnidades_Editar.Text = "";
            }
        }

        protected void Button_Editar_Click(object sender, EventArgs e)
        {
            if (TextBoxGlicemia_Editar.Text != "" & DropDownListInsolina_Editar.Text != "")
            {
                if (registo.verificarNumero(TextBoxGlicemia_Editar.Text))
                {
                    if (DropDownListInsolina_Editar.Text == "Sim" & TextBoxUnidades_Editar.Text != "")
                    {
                        if (TextBoxObservacoes_Editar.Text != "")
                        {
                            panel_editar_valor.Visible = true;
                            labelinsulina_Editar.Visible = true;
                            TextBoxUnidades_Editar.Visible = true;
                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS
                                conexao.Open();
                                comando.CommandText = "UPDATE Dados_Glicemia set Valor_Glicemia = '" + TextBoxGlicemia_Editar.Text + "', Insulina = '" + DropDownListInsolina_Editar.Text + "', Unidades_Administradas = '" + TextBoxUnidades_Editar.Text + "', Observacoes = '" + TextBoxObservacoes_Editar.Text + "' WHERE Id_Doente = '"+username+ "' and DataHora_Add = TO_DATE('" + labelHora_Editar.Text + "','DD-MM-YYYY HH24:MI:SS')";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (guardarGlicemia > 160 || guardarGlicemia < 80)
                                {
                                    if (Convert.ToInt32(TextBoxGlicemia_Editar.Text) > 160 || Convert.ToInt32(TextBoxGlicemia_Editar.Text) < 80)
                                    {
                                        //registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                    }
                                    else
                                    {
                                        registo.EnviarEmail_AlertaAlteracao(email, nome, TextBoxGlicemia_Editar.Text);
                                    }
                                }
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panel_editar_valor.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Problema na ligação com a base de dados, tente novamente!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades_Editar.Text = "";
                            TextBoxObservacoes_Editar.Text = "";
                            TextBoxGlicemia_Editar.Text = "";
                            DropDownListInsolina_Editar.ClearSelection();
                        }
                        else
                        {
                            panel_editar_valor.Visible = true;
                            labelinsulina_Editar.Visible = true;
                            TextBoxUnidades_Editar.Visible = true;

                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS ENVIA OBSERVAÇOES A VAZIO (=0)
                                conexao.Open();
                                comando.CommandText = "UPDATE Dados_Glicemia set Valor_Glicemia = '" + TextBoxGlicemia_Editar.Text + "', Insulina = '" + DropDownListInsolina_Editar.Text + "', Unidades_Administradas = '" + TextBoxUnidades_Editar.Text + "', Observacoes = '' WHERE Id_Doente = '" + username + "' and DataHora_Add = TO_DATE('" + labelHora_Editar.Text + "','DD-MM-YYYY HH24:MI:SS')";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (guardarGlicemia > 160 || guardarGlicemia < 80)
                                {
                                    if (Convert.ToInt32(TextBoxGlicemia_Editar.Text) > 160 || Convert.ToInt32(TextBoxGlicemia_Editar.Text) < 80)
                                    {
                                        //registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                    }
                                    else
                                    {
                                        registo.EnviarEmail_AlertaAlteracao(email, nome, TextBoxGlicemia_Editar.Text);
                                    }
                                }
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panel_editar_valor.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Problema na ligação com a base de dados, tente novamente!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades_Editar.Text = "";
                            TextBoxObservacoes_Editar.Text = "";
                            TextBoxGlicemia_Editar.Text = "";
                            DropDownListInsolina_Editar.ClearSelection();
                        }
                    }
                    else if (DropDownListInsolina_Editar.Text == "Não")
                    {
                        if (TextBoxObservacoes_Editar.Text != "")
                        {
                            panel_editar_valor.Visible = true;

                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS
                                conexao.Open();
                                comando.CommandText = "UPDATE Dados_Glicemia set Valor_Glicemia = '" + TextBoxGlicemia_Editar.Text + "', Insulina = '" + DropDownListInsolina_Editar.Text + "', Unidades_Administradas = '', Observacoes = '" + TextBoxObservacoes_Editar.Text + "' WHERE Id_Doente = '" + username + "' and DataHora_Add = TO_DATE('" + labelHora_Editar.Text + "','DD-MM-YYYY HH24:MI:SS')";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (guardarGlicemia > 160 || guardarGlicemia < 80)
                                {
                                    if (Convert.ToInt32(TextBoxGlicemia_Editar.Text) > 160 || Convert.ToInt32(TextBoxGlicemia_Editar.Text) < 80)
                                    {
                                        //registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                    }
                                    else
                                    {
                                        registo.EnviarEmail_AlertaAlteracao(email, nome, TextBoxGlicemia_Editar.Text);
                                    }
                                }
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panel_editar_valor.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Problema na ligação com a base de dados, tente novamente!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades_Editar.Text = "";
                            TextBoxObservacoes_Editar.Text = "";
                            TextBoxGlicemia_Editar.Text = "";
                            DropDownListInsolina_Editar.ClearSelection();
                        }
                        else
                        {
                            panel_editar_valor.Visible = true;

                            try
                            {
                                //ENVIAR PARA A BASE DE DADOS ENVIA OBSERVAÇOES A VAZIO (=0)
                                conexao.Open();
                                comando.CommandText = "UPDATE Dados_Glicemia set Valor_Glicemia = '" + TextBoxGlicemia_Editar.Text + "', Insulina = '" + DropDownListInsolina_Editar.Text + "', Unidades_Administradas = '', Observacoes = '" + TextBoxObservacoes_Editar.Text + "' WHERE Id_Doente = '" + username + "' and DataHora_Add = TO_DATE('" + labelHora_Editar.Text + "','DD-MM-YYYY HH24:MI:SS')";
                                comando.ExecuteNonQuery();

                                comando.CommandText = "SELECT EMAIL_DOENTE from doente where id_doente = '" + username + "'";
                                string email = Convert.ToString(comando.ExecuteScalar());
                                comando.CommandText = "SELECT nome_doente from doente where id_doente = '" + username + "'";
                                string nome = Convert.ToString(comando.ExecuteScalar());
                                conexao.Close();

                                if (guardarGlicemia > 160 || guardarGlicemia < 80)
                                {
                                    if (Convert.ToInt32(TextBoxGlicemia_Editar.Text) > 160 || Convert.ToInt32(TextBoxGlicemia_Editar.Text) < 80)
                                    {
                                        //registo.EnviarEmail_alerta(email, nome, TextBox_valor.Text);
                                    }
                                    else
                                    {
                                        registo.EnviarEmail_AlertaAlteracao(email, nome, TextBoxGlicemia_Editar.Text);
                                    }
                                }
                            }
                            catch (Oracle.ManagedDataAccess.Client.OracleException)
                            {
                                panel_editar_valor.Visible = true;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Problema na ligação com a base de dados, tente novamente!');", true);
                            }

                            //Limpar todos os campos apos ter sido inseridos os dados
                            TextBoxUnidades_Editar.Text = "";
                            TextBoxObservacoes_Editar.Text = "";
                            TextBoxGlicemia_Editar.Text = "";
                            DropDownListInsolina_Editar.ClearSelection();
                        }
                    }
                    else
                    {
                        panel_editar_valor.Visible = true;
                        labelinsulina_Editar.Visible = true;
                        TextBoxUnidades_Editar.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor, insira as Unidades de Insulina!');", true);
                    }
                }
                else
                {
                    panel_editar_valor.Visible = true;
                    labelValor_Editar.Text = "Introduza um valor válido!";
                }
            }
            else
            {
                panel_editar_valor.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Por favor, preencha todos os campos obrigatorios!');", true);
            }
        }
    }
}