﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doente.aspx.cs" Inherits="scrum_Grupo2_website.html.Doente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doente</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <ul class="topnav">
            <asp:Button class="button" ID="Button1" runat="server" Text="Home" Width="150px" PostBackUrl="~/html/homepage.aspx" UseSubmitBehavior="False"/>
            <asp:Button class="button" ID="btn_paginaInicial" runat="server" Text="Página Inicial" PostBackUrl="~/html/Medico.aspx" UseSubmitBehavior="False"/>
            <asp:Button class="button" ID="btn_faq" runat="server" Text="F.A.Q" PostBackUrl="~/html/Faq.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_contactos" runat="server" Text="Contactos" PostBackUrl="~/html/Contactos.aspx" UseSubmitBehavior="False" />
        </ul>
        <div>
        </div>
    </form>
</body>
</html>
