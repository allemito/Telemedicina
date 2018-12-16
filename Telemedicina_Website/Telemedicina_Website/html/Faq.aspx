<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Faq.aspx.cs" Inherits="Telemedicina_Website.html.Faq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FAQ</title>
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
        <img src="../image/diabetes.jpg" class="background-image" style="padding-top: 70px" />
        <h3 style="padding-left: 20px; color:blue">Quem somos?</h3>
        <h4 style="padding-left: 20px">Somos um grupo da unidade curricular de Telemedicina do terceiro ano do curso de Informática Médica.</h4>
        <h3 style="padding-left: 20px; color:blue">O que fazemos?</h3>
        <h4 style="padding-left: 20px">Realizamos uma aplicação para monitorizar doentes diabéticos que necessitam de vigilancia médica.</h4>
        <h3 style="padding-left: 20px; color:blue">A quem prestamos serviço?</h3>
        <h4 style="padding-left: 20px">Como referido anteriormente, prestamos serviço a doentes diabéticos que necessitam de ser vigiados com frequência.</h4>
        <h3 style="padding-left: 20px; color:blue">Como funcionam os nossos serviços?</h3>
        <h4 style="padding-left: 20px">Após um prévio registo na nossa aplicação, o doente terá acesso a uma area própria onde poderá ai inserir os seus valores glicémicos para serem analizados por um médico.</h4>
        
    </form>
</body>
</html>
