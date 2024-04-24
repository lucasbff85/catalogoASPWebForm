<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Tu selección de artículos favoritos...</h2>

    <asp:GridView ID="dgvFavoritos" SelectedRowStyle-BackColor="Yellow" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvFavoritos_SelectedIndexChanged" OnPageIndexChanging="dgvFavoritos_PageIndexChanging"
        AllowPaging="true" PageSize="5" SelectedRowStyle-Font-Bold="true" SelectedRowStyle-CssClass="table selected" SelectedRowStyle-ForeColor="#08F008">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button ID="btnDetalle" runat="server" CssClass="btn btn-primary" OnClick="btnDetalle_Click" Text="Detalle" />
                <asp:Button ID="btnEliminarFavorito" runat="server" CssClass="btn btn-danger" OnClick="btnEliminarFavorito_Click" Text="Eliminar Favorito" />
            </div>
        </div>
    </div>

</asp:Content>
