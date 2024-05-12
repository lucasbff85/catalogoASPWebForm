using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        public bool EliminarUsuario {  get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if(!string.IsNullOrEmpty(user.UrlImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/"+user.UrlImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");

                    usuario.UrlImagenPerfil = "perfil-" + usuario.Id + ".jpg";

                }

                negocio.actualizar(usuario);
                if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                {
                    Image img = (Image)Master.FindControl("imgAvatar");
                    img.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                    imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                }
                   

            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            EliminarUsuario = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    int id = usuario.Id;
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.eliminarUsuario(id);
                    Session.Clear();
                    Response.Redirect("Default.aspx", false);
                    
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}