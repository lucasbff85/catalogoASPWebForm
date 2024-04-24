<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="ListaDesactivados.aspx.cs" Inherits="Presentacion.ListaDesactivados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="tituloDesactivados" runat="server">Lista de artículos fuera de venta.</h2>

   
    <asp:GridView SelectedRowStyle-BackColor="Yellow" ID="dgvDesactivados" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" runat="server"
        AllowPaging="true" PageSize="5" SelectedRowStyle-Font-Bold="true" SelectedRowStyle-ForeColor="#08F008" OnPageIndexChanging="dgvDesactivados_PageIndexChanging"
        OnSelectedIndexChanged="dgvDesactivados_SelectedIndexChanged">
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
                <label for="txtNuevoPrecio" class="form-label">Ingresa un nuevo precio para la venta</label>
                <asp:TextBox ID="txtNuevoPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" />
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                <asp:Label ID="lblSuspendidos" Visible="false" CssClass="Advertencia" runat="server" />
            </div>
        </div>
    </div>


</asp:Content>
