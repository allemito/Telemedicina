<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Telemedicina_Website.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina Inicial</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/app.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <form id="form1" runat="server" style="margin: auto">
        <ul class="topnav">
            <asp:Button class="button" ID="btn_home" runat="server" Text="Home" PostBackUrl="~/html/homepage.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_login" runat="server" Text="Login" PostBackUrl="~/html/Login.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_faq" runat="server" Text="F.A.Q" PostBackUrl="~/html/Faq.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_contactos" runat="server" Text="Contactos" PostBackUrl="~/html/Contactos.aspx" UseSubmitBehavior="False" />
        </ul>
        <img src="../image/diabetes.jpg" class="background-image" style="padding-top: 100px" />
        <h1 style= "text-align:center">TELEMEDICINA</h1>
        <h2 style= "text-align:center">Monitorização de Diabetes</h2>
        <h3 style= "text-align:center">Grupo III</h3>
    </form>
</body>
</html>
