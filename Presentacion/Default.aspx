<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Bienvenidos a Tecnolandia Online!! Explorá nuestro catálogo y encontrá lo que deseas...</h3>
    <br />
    <div class="row">
        <div class="col-md-8">
            <p>
                Somos una empresa con más de 30 años brindando la mejor calidad y atención. Esto también queremos traertelo en nuestra versión online para que disfrutes desde la comodidad de tu hogar.
Dale un vistazo a nuestro catálogo, <a href="Registro.aspx">registra tu perfil</a>  y seguí de cerca tus productos favoritos...
            </p>

        </div>
        <div class="col-md-4">
        </div>
        <div class="row">
            <div class="col-md-6">
                <img src="https://st3.depositphotos.com/1006463/35735/i/450/depositphotos_357356270-stock-photo-render-home-appliances-collection-set.jpg" class="img img-ppal" alt="Imagen electrodomésticos" /></div>
            <div class="col-md-6">
                <img class="img-ppal" src="https://www.milar.es/statics/store/00/00/09/17/b3ba50ef3ced11bca79cbc45d8fa8dddeb2188c5.jpg" alt="Imagen tienda" />
            </div>

            

        </div>
    </div>

</asp:Content>
