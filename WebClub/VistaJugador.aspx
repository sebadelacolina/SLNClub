<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaJugador.aspx.cs" Inherits="WebClub.VistaJugador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID:
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            NOMBRE:
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            APELLIDO:
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            FECHA DE NACIMIENTO:
            <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
            <br />
            PUESTO:
            <asp:DropDownList ID="ddlPuesto" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            BUSCAR POR&nbsp; PUESTO
            <asp:DropDownList ID="ddlBuscar" runat="server" OnSelectedIndexChanged="ddlBuscar_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="EDITAR" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" />
        </div>
        <asp:Label ID="lblPrueba" runat="server" Text="puesto"></asp:Label>
        <br />
        <asp:GridView ID="gridJugador" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
