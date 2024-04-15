<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webform1.aspx.cs" Inherits="Practico._01.webform1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Encuestas De Calidad De Servicio"></asp:Label>

        <p>
            <asp:Label ID="Label2" runat="server" Text="¿Usted está conforme con los servicios brindados por ISSD?"></asp:Label>
        </p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="1">SI</asp:ListItem>
            <asp:ListItem Value="0">NO</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="¿Recomendaría nuestros servicios a alguien más?"></asp:Label>
        <br />
        <br />
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="21px">
            <asp:ListItem Value="1">SI</asp:ListItem>
            <asp:ListItem Value="0">NO</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="25px" OnClick="Button1_Click" Text="Cargar" Width="91px" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
