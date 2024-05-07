<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Bienvenidos a Musimundo Online!! Explorá nuestro catálogo y encontrá lo que deseas...</h4> 
    <br />
    <div class="row">
        <div class="col-md-8">Somos una empresa con más de 30 años brindando la mejor calidad y atención. Esto también queremos traertelo en nuestra versión online para que disfrutes desde la comodidad de tu hogar.
            Dale un vistazo a nuestro catálogo, <a href="Registro.aspx">registra tu perfil</a>  y seguí de cerca tus productos favoritos.
        </div>
        <div class="col-md-4">
            <img src="/Images/a.png" alt="Alternate Text" />
            <%--ruta absoluta para subir esa imagen--%> 
        </div>
    </div>

</asp:Content>
