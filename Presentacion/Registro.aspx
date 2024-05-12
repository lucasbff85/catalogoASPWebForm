<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Presentacion.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <h2>Registrate!!</h2>
            <br />
            <div class="mb-3">
                <asp:Label Text="Email" CssClass="form-label" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" />
                <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="12pt" ErrorMessage="Por favor ingresa tu email." ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="12pt" ErrorMessage="Email inválido." ValidationExpression=".*@.*" ControlToValidate="txtEmail" runat="server" />      
            </div>
            <div class="mb-3">
                <asp:Label Text="Password" CssClass="form-label" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ForeColor="Red" Font-Bold="true" Font-Italic="true" Font-Size="12pt" ErrorMessage="Por favor ingresa tu contraseña." ControlToValidate="txtPassword" runat="server" />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>
            <div class="mb-3">
                <h4>Ya tienes una cuenta?</h4>
                <a href="Login.aspx">Iniciar sesión</a>
            </div>
        </div>

    </div>

</asp:Content>
