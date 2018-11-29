﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistoUtente.aspx.cs" Inherits="scrum_Grupo2_website.html.RegistoUtente1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina Administrador</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <form id="form1" runat="server" style="margin: auto">
        <ul class="topnav">
            <asp:Button class="button" ID="btn_home" runat="server" Text="Home" PostBackUrl="~/html/homepage.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_paginaInicial" runat="server" Text="Página Inicial" PostBackUrl="~/html/Administrador.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_faq" runat="server" Text="F.A.Q" PostBackUrl="~/html/Faq.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_contactos" runat="server" Text="Contactos" PostBackUrl="~/html/Contactos.aspx" UseSubmitBehavior="False" />
        </ul>
        <div style="height: 590px; margin: 0 auto; width: 520px;">
            <img src="../image/diabetes.jpg" class="background-image" />

            <h1>Registo Utente</h1>

            <p>Insira os dados para criar a sua conta.</p>
            <label for="nome"><b>Nome:</b></label>
            <asp:TextBox type="text" ID="txtbox_nome" runat="server" placeholder="Nome" name="nome"></asp:TextBox>

            <label><b>Número de Utente:</b></label>
            <asp:TextBox type="text" ID="TextBox_numeroutente" runat="server" placeholder="Número de Utente" name="numero_utente"></asp:TextBox>

            <p><label><b>Data de Nascimento:</b></label> 
            <asp:Calendar ID="Calendar_datanascimento" runat="server" AutoPostBack = "false"></asp:Calendar>
            </p>
           
            <label><b>Género:</b></label>
            <p>
                <asp:DropDownList ID="DropDownList_Sexo" runat="server">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </p>
            <label for="morada"><b>Morada:</b></label>
            <asp:TextBox type="text" ID="TextBox_morada" runat="server" placeholder="Morada" name="morada"></asp:TextBox>

            <label for="email"><b>Email:</b></label>
            <asp:TextBox type="text" ID="txtbox_email" runat="server" placeholder="Email" name="email"></asp:TextBox>

            <asp:Button type="submit" ID="btn_registar" class="registerbtn" runat="server" Text="Criar" OnClick="btn_registar_Click" />
        </div>
    </form>
</body>
</html>
