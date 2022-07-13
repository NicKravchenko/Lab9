<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebFormApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem NavigateUrl="~/PaginaSession.aspx.cs" Text="Session" Value="Session"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/AccesoAdatos.aspx" Text="Acceso" Value="Acceso"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FFCC66" />
            </asp:Menu>
        </div>
        <br />
        Vehiculo<asp:DropDownList ID="ddlCiudad" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Monto:<asp:TextBox ID="txtEdad" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Entrar" />
        <br />
        <br />
        Cedula:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Nombre:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnVer" runat="server" Height="25px" OnClick="btnVer_Click" Text="Ver" Width="90px" />
        <br />
        <br />
        <br />
        <br />
        <br />
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        <br />
        <p>
            <asp:FileUpload ID="fuArchivo" runat="server" AllowMultiple="True" />
        </p>
        <asp:Image ID="ingFoto" runat="server" />
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Height="182px" style="margin-bottom: 117px" TextMode="MultiLine" Width="438px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
