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

        public List<Articulo> ListaFavoritos { get; set; }


       

        public void cargarFavoritos()
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            try
            {

                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    user = (Usuario)Session["usuario"];
                    int id = user.Id;

                    Session.Add("listaFavoritos", negocio.listarFavoritos(id));
                    ListaFavoritos = (List<Articulo>)Session["listaFavoritos"];
                    repRepetidor.DataSource = Session["listaFavoritos"];
                    repRepetidor.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                ListaFavoritos = (List<Articulo>)Session["listaFavoritos"];
                if (!IsPostBack)
                {
                    cargarFavoritos();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }



        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("FormularioArticulo.aspx?id=" + id, false);
            Session.Add("banderaDetalle", true);
        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            int idUser = user.Id;
            int idArticulo = Convert.ToInt32(((Button)sender).CommandArgument);


            try
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                negocio.eliminarFavorito(idUser, idArticulo);

                // Actualiza la lista de favoritos en la sesión
                Session["listaFavoritos"] = negocio.listarFavoritos(idUser);

                // Verifica si la lista de favoritos está vacía después de eliminar un favorito


                //if (ListaFavoritos == null || ListaFavoritos.Count == 0)
                if (Session["listaFavoritos"] == null || ((List<Articulo>)Session["listaFavoritos"]).Count == 0)
                {
                    // Si la lista está vacía, redirige al usuario a ListaArticulos.aspx
                    Response.Redirect("ListaArticulos.aspx", false);
                }
                else
                {
                    // Si la lista no está vacía, vuelve a cargar los favoritos
                    cargarFavoritos();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }


        }


        //METODO QUE NO FUNCIONO PARA CARGAR IMG POR DEFAULT
        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        //    string imgDefault = "https://www.nycourts.gov/courts/ad4/assets/Placeholder.png";


        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Articulo articulo = (Articulo)e.Item.DataItem;
        //        Image imgArticulo = (Image)e.Item.FindControl("imgArticulo");
        //        imgArticulo.ImageUrl = imgDefault;
        //        if (!(string.IsNullOrEmpty(articulo.UrlImagen)))
        //        {
        //            imgArticulo.ImageUrl = articulo.UrlImagen;
        //        }

        //    }
        }
    }
}