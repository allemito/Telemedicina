﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="scrum_Grupo2_website.html.Contactos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contactos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <form id="form1" runat="server" style="margin: auto">
        <ul class="topnav">
            <asp:Button class="button" ID="btn_home" runat="server" Text="Home" PostBackUrl="~/html/homepage.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_login" runat="server" Text="Login" PostBackUrl="~/html/Login.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_faq" runat="server" Text="F.A.Q" PostBackUrl="~/html/Faq.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_contactos" runat="server" Text="Contactos" PostBackUrl="~/html/Contactos.aspx" UseSubmitBehavior="False" />
        </ul>   
        <img src="../image/heart-health-main.jpg" class="background-image" />     
    </form>
</body>
</html>

