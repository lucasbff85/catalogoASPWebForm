using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        
        public bool ConfirmaEliminacion { get; set; }
        public bool FiltroAvanzado { get; set; }

        
        private void cargarDGV()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdvertencia.Visible = false;
            lblSuspendidos.Visible = false;
            //FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
                cargarDGV();
            ConfirmaEliminacion = false;
        }


        public void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            
        }


        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            cargarDGV();
            dgvArticulos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }


        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            cargarDGV();
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !chkAvanzado.Checked;

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCampo.SelectedItem != null)
                {
                    txtFiltroAvanzado.Visible = false;
                    lblFiltroAvanzado.Visible = false;

                    string opcion = ddlCampo.SelectedItem.Text;
                    switch (opcion)
                    {

                        case "Precio":
                            txtFiltroAvanzado.Visible = true;
                            lblFiltroAvanzado.Visible = true;
                            ddlCriterio.DataSource = null;
                            ddlCriterio.Items.Clear();
                            ddlCriterio.Items.Add("Igual a");
                            ddlCriterio.Items.Add("Mayor a");
                            ddlCriterio.Items.Add("Menor a");
                            break;

                        case "Marca":
                            txtFiltroAvanzado.Visible = false;
                            lblFiltroAvanzado.Visible = false;
                            ddlCriterio.DataSource = null;
                            ddlCriterio.Items.Clear();
                            MarcaNegocio marcaNegocio = new MarcaNegocio();
                            ddlCriterio.DataSource = marcaNegocio.listar();
                            ddlCriterio.DataBind();
                            break;

                        case "Categoría":
                            txtFiltroAvanzado.Visible = false;
                            lblFiltroAvanzado.Visible = false;
                            ddlCriterio.DataSource = null;
                            ddlCriterio.Items.Clear();
                            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                            ddlCriterio.DataSource = categoriaNegocio.listar();
                            ddlCriterio.DataBind();
                            break;

                        default:
                            ddlCriterio.SelectedIndex = 0;
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
            
        }

        private bool validarFiltro()
        {
            Validaciones validar = new Validaciones();

            if (ddlCampo.SelectedIndex <= 0)
            {
                lblAdvertencia.Visible = true;
                lblAdvertencia.Text = "Selecciona el campo para filtrar";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertBox", "alert('Selecciona el campo para filtrar');", true); //alerta de JS
                return true;
            }


            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                txtFiltroAvanzado.Text = txtFiltroAvanzado.Text.Replace(',', '.');

                if (!decimal.TryParse(txtFiltroAvanzado.Text, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out decimal valor))
                {
                    lblAdvertencia.Visible = true;
                    lblAdvertencia.Text = "Formato de precio inválido";
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertBox", "alert('Formato de precio inválido');");
                    return true;
                }
                if (validar.validarPrecio(txtFiltroAvanzado.Text))
                {
                    return true;
                }
            }

            //if (ddlCampo.SelectedItem.ToString() == "Precio")
            //{
               

            //}
            return false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarFiltro())
                    return;

                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargarDGV();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.SelectedDataKey != null && dgvArticulos.SelectedDataKey.Value != null)
                {
                    string id = dgvArticulos.SelectedDataKey.Value.ToString();
                    Response.Redirect("FormularioArticulo.aspx?id=" + id, false);
                    Session.Add("banderaDetalle", false);
                }
                else
                    return;
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }




        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmarEliminacion.Checked)
                {
                    if (dgvArticulos.SelectedDataKey != null && dgvArticulos.SelectedDataKey.Value != null)
                    {
                        int id = Convert.ToInt32(dgvArticulos.SelectedDataKey.Value);
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        negocio.eliminar(id);
                        cargarDGV();
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSuspender_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.SelectedDataKey != null && dgvArticulos.SelectedDataKey.Value != null)
                {
                    int id = Convert.ToInt32(dgvArticulos.SelectedDataKey.Value);
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.suspender(id);
                    cargarDGV();
                    lblSuspendidos.Text = "El artículo que desactivaste ingresó a la lista de artículos suspendidos, selecciona activar para volverlo a la línea de venta.";
                    lblSuspendidos.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
           
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaSuspendidos = negocio.listarSuspendidos();
                if (listaSuspendidos.Count > 0)
                {
                    Session.Add("listaArticulosDesactivados", listaSuspendidos);
                    Response.Redirect("ListaDesactivados.aspx", false);
                }
                else
                {
                    lblSuspendidos.Text = "No hay artículos suspendidos en este momento.";
                    lblSuspendidos.Visible = true;
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
            try
            {
                if (dgvArticulos.SelectedDataKey != null && dgvArticulos.SelectedDataKey.Value != null)
                {
                    string id = dgvArticulos.SelectedDataKey.Value.ToString();
                    Response.Redirect("FormularioArticulo.aspx?id=" + id, false);
                    Session.Add("banderaDetalle", true);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.SelectedDataKey != null && dgvArticulos.SelectedDataKey.Value != null)
                {

                    Usuario User = (Usuario)Session["usuario"];
                    int idArticulo = Convert.ToInt32(dgvArticulos.SelectedDataKey.Value);
                    int idUser = User.Id;
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    favoritoNegocio.agregarFavorito(idUser, idArticulo);
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