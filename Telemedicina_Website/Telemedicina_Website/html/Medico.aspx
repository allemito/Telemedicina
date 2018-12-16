<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medico.aspx.cs" Inherits="Telemedicina_Website.Medico" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Pagina Medico</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/app.css" rel="stylesheet" type="text/css" media="screen" runat="server" />

</head>
<body>
    <form id="form1" runat="server" style="margin: auto">
        <ul class="topnav">
            <asp:Button class="button" ID="Button1" runat="server" Text="Home" Width="150px" PostBackUrl="~/html/homepage.aspx" UseSubmitBehavior="False"/>
            <asp:Button class="button" ID="btn_paginaInicial" runat="server" Text="Página Inicial" PostBackUrl="~/html/Medico.aspx" UseSubmitBehavior="False"/>
            <asp:Button class="button" ID="btn_faq" runat="server" Text="F.A.Q" PostBackUrl="~/html/Faq.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_contactos" runat="server" Text="Contactos" PostBackUrl="~/html/Contactos.aspx" UseSubmitBehavior="False" />
        </ul>
        <ul class="med">
            <asp:Button class="btnmed" ID="ButtonProcurar" runat="server" Text="Procurar" Width ="150px" OnClick="ButtonProcurar_Click"/> 
            <asp:TextBox type="text" ID="TextBox_Procurar" runat="server" placeholder="Número de Utente" name="numero_utente" Width ="150px"></asp:TextBox>   
            <asp:label ID="labelProcurar" runat="server" Width ="150px" style="text-align:center" ForeColor="Red"><b></b></asp:label>          
        </ul>
        <div style="height: 590px; margin-left:150px; padding: 20px; border-color: lightseagreen; width: auto;">
            <asp:Panel ID ="panelDoente" runat ="server">
                <h1>Informação Clínica</h1>
                <label><b>Nome:</b></label>
                <asp:TextBox type="text" ID="TextBox_Nome" runat="server" placeholder="Nome" name="nome"></asp:TextBox>
                <label><b>Alertas:</b></label>
                <asp:Label ID="label_alertas" runat="server" ForeColor="Red"></asp:Label><p></p>
                <asp:Chart ID="ChartGlicemia" runat="server" Width="1042px" Palette="Berry">
                    <Titles><asp:Title Text="Niveis de Glicemia"></asp:Title></Titles>
                    <Series>
                        <asp:Series Name="Glicemia" ChartType="Line" YValuesPerPoint="6"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Title="Dia da Semana"></AxisX>
                            <AxisY Title="Valores de Glicemia">
                        </AxisY></asp:ChartArea>                       
                    </ChartAreas>
                </asp:Chart>
                <p><asp:Button class="button" ID="ButtonVer_Total" runat="server" Text="Informações Glicêmicas" Width="217px" OnClick="ButtonVer_Total_Click" /></p>
            </asp:Panel>
            <asp:Panel ID ="panelDados" runat ="server">
                <asp:Button class="button" ID="ButtonParaTras" runat="server" Text="Voltar Atras" Width="217px" OnClick="ButtonParaTras_Click" />
                <h1>Informação Glicêmica</h1>
                <label><b>Nome:</b></label>
                <asp:TextBox type="text" ID="TextBoxnome" runat="server" placeholder="Nome" name="nome"></asp:TextBox>
                <p><asp:GridView ID="GridViewGlicemia" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView></p> 
            </asp:Panel>
        </div>
    </form>
</body>
</html>
