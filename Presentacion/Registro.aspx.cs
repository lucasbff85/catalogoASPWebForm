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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    Session.Add("error", "Debes completar ambos campos.");
                    Response.Redirect("Error.aspx");
                }

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;

                if(negocio.usuarioExistente(usuario))
                {
                    Session.Add("error", "El email ya está en uso.");
                    Response.Redirect("Error.aspx");
                }

                negocio.agregarUsuario(usuario);
                Session.Add("usuario", usuario);
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}