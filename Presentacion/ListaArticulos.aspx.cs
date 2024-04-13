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
        public bool FiltroAvanzado {  get; set; }
        private void cargarDGV()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //FiltroAvanzado = chkAvanzado.Checked;
            if(!IsPostBack)
                cargarDGV();

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            //Response.Redirect("FormularioArticulo.aspx?id=" + id);    LOGICA PARA MODIFICAR ARTICULO CON CUENTA ADMIN
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
            dgvArticulos.DataSource= listaFiltrada;
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

                    default :
                        ddlCriterio.SelectedIndex = 0;
                        break;

                }
            }
        }

        private bool validarFiltro()
        {
            Validaciones validar = new Validaciones();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                if(ddlCampo.SelectedIndex <= 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertBox", "alert('Selecciona el campo para filtrar');", true); //alerta de JS
                    return true;
                }
                if (ddlCampo.SelectedItem.Value.ToString() == "Precio")
                {
                    txtFiltroAvanzado.Text = txtFiltroAvanzado.Text.Replace(',', '.');

                    if (!decimal.TryParse(txtFiltroAvanzado.Text, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out decimal valor))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertBox", "alert('Formato de precio inválido');");
                        return true;
                    }
                    if (validar.validarPrecio(txtFiltroAvanzado.Text))
                    {
                        return true;
                    }
                }
                
            }
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

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargarDGV();
        }
    }
}