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
    public partial class Favoritos : System.Web.UI.Page
    {
        public Usuario user { get; set; }

        public int id { get; set; }

        private void cargarFavoritos()
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            try
            {
                
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    user = (Usuario)Session["usuario"];
                    int id = user.Id;
                    
                    Session.Add("listaFavoritos", negocio.listarFavoritos(id));
                    dgvFavoritos.DataSource = Session["listaFavoritos"];
                    dgvFavoritos.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarFavoritos();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string id = dgvFavoritos.SelectedDataKey.Value.ToString();
        }

        protected void dgvFavoritos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvFavoritos.SelectedDataKey != null && dgvFavoritos.SelectedDataKey.Value != null)
                {
                    string id = dgvFavoritos.SelectedDataKey.Value.ToString();
                    Response.Redirect("FormularioArticulo.aspx?id=" + id, false);
                    Session.Add("banderaDetalle", true);
                }
                else
                    return;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            int idUser = user.Id;
            int idArticulo = Convert.ToInt32(dgvFavoritos.SelectedDataKey.Value);
            try
            {
                
                FavoritoNegocio negocio = new FavoritoNegocio();
                negocio.eliminarFavorito(idUser, idArticulo);
                if (Session["listaFavoritos"] != null && ((List<Articulo>)Session["listaFavoritos"]).Count > 0)
                    cargarFavoritos();
                else
                    Response.Redirect("ListaArticulos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}