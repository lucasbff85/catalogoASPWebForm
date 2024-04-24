<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Presentacion.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager1" runat="server" />
    <h2 id="h2Form" runat="server"></h2>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" id="lblId" class="form-label" runat="server">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server" />
            </div>
            <div class="mb-3">
                <labe for="ddlMarca" class="form-label">Marca</labe>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                    <asp:TextBox ID="txtImagenUrl" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    <asp:Image ImageUrl="imageurl" Width="60%" ID="imgArticulo" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" />
                <asp:Button ID="btnAceptar" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" runat="server" />
            </div>
        </div>
    </div>


</asp:Content>
