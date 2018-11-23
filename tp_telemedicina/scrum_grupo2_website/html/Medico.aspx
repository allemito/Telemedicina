﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medico.aspx.cs" Inherits="scrum_Grupo2_website.Medico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Pagina Medico</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="~/css/leftbar.css" rel="stylesheet" type="text/css" media="screen" runat="server" />

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
                <asp:TextBox type="text" ID="TextBox_Nome" runat="server" placeholder="Nome" name="nome"></asp:TextBox>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
