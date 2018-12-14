<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="Telemedicina_Website.html.Contactos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contactos</title>
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
        <div class="mapouter">
            <h2 style="text-align:center">Localização</h2>
            <div class="gmap_canvas">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2986.512025019301!2d-8.630111948667484!3d41.536509679149056!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd2453cb20c42a05%3A0xf840740c7c32e88!2sInstituto+Polit%C3%A9cnico+do+C%C3%A1vado+e+do+Ave!5e0!3m2!1spt-PT!2spt!4v1544097552814" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
            </div>
            <h3 style="text-align:center">Email: telemedicina@ipca.com</h3>
            <h3 style="text-align:center">Contacto: 912 345 678</h3>
        </div>
    </form>
</body>
</html>

