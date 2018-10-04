<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="Telemedicina.registo" %>

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
    <form id="form1" runat="server">
        <ul class="topnav">
            <asp:Button class="button" ID="btn_home" runat="server" Text="Home" PostBackUrl="~/html/home.aspx" />
            <asp:Button class="button" ID="btn_registo" runat="server" Text="Registo" PostBackUrl="~/html/registo.aspx" />
        </ul>
    <div style="height: 336px; width: 528px; margin:auto;">
            <h1>CardioMaker</h1>
            <label><b>Nome:</b></label>
            <asp:TextBox type="text" ID="txtbox_Nome" runat="server" placeholder="Nome" name="nome"></asp:TextBox>
            <label><b>Data de Nascimento:</b></label>
            <asp:TextBox type="text" ID="txtbox_DataNascimento" runat="server" placeholder="DD-MM-AA" name="Data_Nascimento"></asp:TextBox>
            <label><b>Morada:</b></label>
            <asp:TextBox type="text" ID="TextBox_Morada" runat="server" placeholder="Morada" name="Morada"></asp:TextBox>
            <label><b>Código Postal:</b></label>
            <asp:TextBox type="text" ID="TextBox_CodigoPostal" runat="server" placeholder="____ - ___" name="CodigoPostal"></asp:TextBox>
            <label><b>Contacto:</b></label>
            <asp:TextBox type="text" ID="TextBox_Contacto" runat="server" placeholder="Contacto" name="Contacto"></asp:TextBox>
            <label><b>E-mail:</b></label>
            <asp:TextBox type="text" ID="TextBox_Email" runat="server" placeholder="E-mail" name="Email"></asp:TextBox>
            <label><b>Password:</b></label>
            <asp:TextBox type="password" ID="TextBox_Password1" runat="server" placeholder="Password" name="Password1"></asp:TextBox>
            <label><b>Confirme a Password:</b></label>
            <asp:TextBox type="password" ID="TextBox_Password2" runat="server" placeholder="Password" name="Password2"></asp:TextBox>
            <asp:Button ID="btn_Registar" runat="server" Text="Concluir Registo" class="registerbtn" OnClick="btn_Registar_Click" />
        </div>
    </form>
</body>
</html>
