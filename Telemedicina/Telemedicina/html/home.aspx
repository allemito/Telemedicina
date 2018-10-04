<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Telemedicina.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        CardioMaker
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link rel="icon" href="~/imagens/cardiology-512.ico" />
</head>
<body>
    <form id="form1" runat="server" style="margin: auto">
        <ul class="topnav">
            <asp:Button class="button" ID="btn_home" runat="server" Text="Home" PostBackUrl="~/html/home.aspx" />
            <asp:Button class="button" ID="btn_registo" runat="server" Text="Registo" PostBackUrl="~/html/registo.aspx" />
        </ul>
        <img src="../imagens/cardiac.jpg" class="background-image" />   
        <div style="height: 336px; width: 528px; margin:auto;">
            <h1>Login</h1>
            <label for="username"><b>Username</b></label>
            <asp:TextBox type="text" ID="txtbox_username" runat="server" placeholder="Username" name="username"></asp:TextBox>

            <label for="psw_login"><b>Password</b></label>
            <asp:TextBox type="password" ID="txtbox_password" runat="server" placeholder="Password" name="psw_login"></asp:TextBox>

            <asp:Button ID="btn_login_account" runat="server" Text="Login" class="registerbtn" />
        </div>
        
    </form>
</body>
</html>
