<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doente.aspx.cs" Inherits="Telemedicina_Website.html.Doente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doente</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/app.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <ul class="topnav">
            <asp:Button class="button" ID="Button1" runat="server" Text="Home" Width="150px" PostBackUrl="~/html/homepage.aspx" UseSubmitBehavior="False"/>
            <asp:Button class="button" ID="btn_paginaInicial" runat="server" Text="Página Inicial" PostBackUrl="~/html/Doente.aspx" UseSubmitBehavior="False"/>
            <asp:Button class="button" ID="btn_faq" runat="server" Text="F.A.Q" PostBackUrl="~/html/Faq.aspx" UseSubmitBehavior="False" />
            <asp:Button class="button" ID="btn_contactos" runat="server" Text="Contactos" PostBackUrl="~/html/Contactos.aspx" UseSubmitBehavior="False" />
        </ul>
        <ul class="doente">
            <asp:Button class="btndoente" ID="ButtonAddGlicemia" runat="server" Text="Glicemia" Width ="150px" OnClick="ButtonAddGlicemia_Click"/>        
        </ul>
        <div style="height: 590px; margin-left:150px; padding: 20px; border-color: lightseagreen; width: auto;">
            <asp:Panel ID ="panelValores" runat="server">
                <p><asp:Label ID="labelDiaHora" runat="server"></asp:Label></p>
                <label for="valor"><b>Valor de Glicemia:</b></label>
                <asp:TextBox type="text" ID="TextBox_valor" runat="server" placeholder="Glicemia" name="valor_glicemia"></asp:TextBox>
                <asp:Label ID="label_valor" runat="server" ForeColor="Red"></asp:Label>
                <p><label><b>Administração de Insulina:</b></label></p>
                <p><asp:DropDownList ID="DropDownListInsolina" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListInsolina_SelectedIndexChanged">
                    <asp:ListItem>Não</asp:ListItem>
                    <asp:ListItem>Sim</asp:ListItem>      
                </asp:DropDownList></p>
                <asp:Label ID="labelInsolina" runat="server"><b>Unidades Administradas:</b></asp:Label>
                <p><asp:TextBox type="text" ID="TextBoxUnidades" runat="server" name="valor_glicemia" TextMode="Number" Min ="0"></asp:TextBox></p>
                <label><b>Observações Pertinentes:</b></label>
                <asp:TextBox type="text" ID="TextBox_Observacoes" runat="server" placeholder="Observações" name="valor_glicemia"></asp:TextBox>
                <p><asp:Button ID="btn_adicionar_valor" runat="server" Text="Gravar" class="registerbtn" OnClick="btn_adicionar_valor_Click"/></p>           
            </asp:Panel>
        </div>
    </form>
</body>
</html>
