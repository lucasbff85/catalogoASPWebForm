<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Presentacion.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h1>lista de articulos</h1>


    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" runat="server" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" CssClass="form-check" AutoPostBack="true" ID="chkAvanzado" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
                <asp:Button Text="Limpiar Filtro" ID="btnLimpiar" CssClass="btn btn-primary" OnClick="btnLimpiar_Click" runat="server" />
            </div>
        </div>
    </div>




    <%if (chkAvanzado.Checked)
        {%>


    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Selecciona un campo" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoría" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Selecciona un criterio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" ID="lblFiltroAvanzado" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
        <div class="col-3"></div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
    </div>

    <%} %>


    <asp:GridView runat="server" AutoPostBack="true" ID="dgvArticulos" SelectedRowStyle-BackColor="Yellow" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="5" SelectedRowStyle-Font-Bold="true" SelectedRowStyle-CssClass="table selected" SelectedRowStyle-ForeColor="#08F008">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
        <RowStyle CssClass="tr" />
    </asp:GridView>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label>Podes seleccionar artículos que te gustan y verlos en tu lista de favoritos en tu perfil!! </label>
                <asp:Button Text="Agregar Favorito" ID="btnAgregarFavorito" OnClick="btnAgregarFavorito_Click" CssClass="btn btn-primary" runat="server" />
                <asp:Button Text="Detalle" CssClass="btn btn-primary" ID="btnDetalle" OnClick="btnDetalle_Click" runat="server" />
            </div>
        </div>
    </div>



    <asp:Label ID="lblSuspendidos" CssClass="Advertencia" runat="server" />

    <%if (Negocio.Seguridad.esAdmin(Session["usuario"]))
        {%>
    <h5>Panel de Administrador</h5>

    <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    <asp:Button Text="Modificar" CssClass="btn btn-warning" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
    <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
    <asp:Button Text="Suspender" CssClass="btn btn-warning" ID="btnSuspender" OnClick="btnSuspender_Click" runat="server" />
    <asp:Button Text="Activar" CssClass="btn btn-info" ID="btnActivar" OnClick="btnActivar_Click" runat="server" />
    <%} %>


    <%if (ConfirmaEliminacion)
        {%>
    <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmarEliminacion" runat="server" />
    <asp:Button Text="Eliminar" ID="btnConfirmarEliminacion" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" runat="server" />
    <%}%>
</asp:Content>

