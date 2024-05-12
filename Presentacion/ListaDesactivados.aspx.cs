using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ListaDesactivados : System.Web.UI.Page
    {
        private void cargarDGVSusp()
        {
            dgvDesactivados.DataSource = Session["listaArticulosDesactivados"];
            dgvDesactivados.DataBind();
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                dgvDesactivados.DataSource = Session["listaArticulosDesactivados"];
                dgvDesactivados.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvDesactivados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDesactivados.PageIndex = e.NewPageIndex;
            cargarDGVSusp();
            dgvDesactivados.DataBind();
        }

        protected void dgvDesactivados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDesactivados.SelectedDataKey.Value.ToString();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaArticulos.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Validaciones validaciones = new Validaciones();
            Articulo seleccionado = new Articulo();
            try
            {


                txtNuevoPrecio.Text = txtNuevoPrecio.Text.Replace(',', '.');

                if (!decimal.TryParse(txtNuevoPrecio.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal nuevoPrecio) || validaciones.validarPrecio(txtNuevoPrecio.Text))
                {
                    lblSuspendidos.Text = "El formato de precio no es válido";
                    lblSuspendidos.Visible = true;
                    return;
                }
  
                seleccionado.Id = Convert.ToInt32(dgvDesactivados.SelectedDataKey.Value);
                seleccionado.Precio = decimal.Parse(txtNuevoPrecio.Text);

                decimal precio = nuevoPrecio;
                seleccionado.Precio = precio;

                negocio.modificarPrecio(seleccionado);
                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", Seguridad.manejoError(ex));
                Response.Redirect("Error.aspx", false);
            }
             
        }
    }
}