 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCatalogo.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Presentacion.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>
    <script src="Scripts.js"></script>
    <script>
        function validar() {
            const txtApellido = document.getElementById("txtApellido");
            const txtNombre = document.getElementById("txtNombre");


            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                return false;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }
            if (txtNombre.value == "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                return false;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }
  
            return true;
        }

       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" ClientIDMode="Static" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" ClientIDMode="Static" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ImageUrl="https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png" runat="server" ID="imgNuevoPerfil"
                CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClientClick="return validar()" OnClick="btnGuardar_Click" runat="server" />
            <asp:Button Text="Eliminar usuario" CssClass="btn btn-danger" ID="btnEliminarUsuario" OnClick="btnEliminarUsuario_Click" runat="server" />
        </div>
        <%if (EliminarUsuario) {  %>
        <div class="row">
            <div class="col-md-4">
                <asp:CheckBox Text="Confirmar Eliminación" CssClass="btn btn-danger" ID="chkConfirmarEliminacion" runat="server" />
                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
            </div>
        </div>
        <% }%>

    </div>
</asp:Content>
