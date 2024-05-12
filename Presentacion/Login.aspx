<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <h2>Iniciar sesión</h2>
            <br />
            <div class="mb-3">
                <asp:Label Text="Email" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="12pt" ErrorMessage="Por favor ingresa tu email." ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="12pt" ErrorMessage="Email inválido." ValidationExpression=".*@.*" ControlToValidate="txtEmail" runat="server" />

            </div>
            <div class="mb-3">
                <asp:Label Text="Password" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="12pt" ErrorMessage="Por favor ingresa tu contraseña." ControlToValidate="txtPassword" runat="server" />
            </div>
            <asp:Button Text="Ingresar" CssClass=" btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
            <a href="/">Cancelar</a>
            <div class="mb-3">
                <h4>No tenés una cuenta?</h4>
                <a href="Registro.aspx">Registrate</a>
            </div>
        </div>
    </div>

</asp:Content>
