<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            max-width: 100%;
            height: 400px;
        }
    </style>

    <script>
        function ImagenDefecto() {
            this.onerror = null;
            this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740';
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%if (ListaFavoritos == null || ListaFavoritos.Count == 0)
        {%>
    <label>Aún no tienes favoritos en tu lista, elígelos desde la lista de artículos...</label>
    <% }
        else
        {%>

    <h2>Tu selección de artículos favoritos...</h2>


    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <%--<img src="<%# Eval("UrlImagen")%>" class="card-img-top" alt="imagen de artículo">--%>
                        <%--<asp:Image CssClass="card-img-top" ID="imgArticulo" AlternateText="Imagen de artículo" runat="server" />--%>
                        <img src="<%#Eval("UrlImagen")%>" onerror="this.onerror=null; this.src = 'https://www.nycourts.gov/courts/ad4/assets/Placeholder.png'" class="card-img-top">
                        <%-- <img src="<%# string.IsNullOrEmpty(Eval("UrlImagen").ToString()) ? "https://www.nycourts.gov/courts/ad4/assets/Placeholder.png" : Eval("UrlImagen").ToString() %>" class="card-img-top" alt="imagen de artículo">--%>


                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <div class="card-bottom">
                                <asp:Button ID="btnDetalle" runat="server" CssClass="btn btn-primary" OnClick="btnDetalle_Click" Text="Detalle" CommandArgument='<%#Eval("Id") %>' CommandName="articuloId" />
                                <asp:Button ID="btnEliminarFavorito" runat="server" CssClass="btn btn-danger" OnClick="btnEliminarFavorito_Click" Text="Eliminar Favorito" CommandArgument='<%#Eval("Id") %>' CommandName="articuloId" />
                            </div>

                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>

    <%} %>
</asp:Content>
