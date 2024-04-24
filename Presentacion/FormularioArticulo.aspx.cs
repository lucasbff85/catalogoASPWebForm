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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            bool esDetalle = Session["banderaDetalle"] != null && (bool)Session["banderaDetalle"];
            Console.WriteLine("Es detalle: " + esDetalle);


            if (Request.QueryString["id"] == null)
            {
                h2Form.InnerText = "Agregar Artículo";
                lblId.Visible = false;
                txtId.Visible = false;
            }
            else if(!esDetalle)
            {
                h2Form.InnerText = "Modificar Artículo";
                btnAceptar.Visible = true;
                btnCancelar.Text = "Cancelar";
                txtCodigo.Enabled = true;
                txtNombre.Enabled = true;
                ddlCategoria.Enabled = true;
                ddlMarca.Enabled = true;
                txtPrecio.Enabled = true;
                txtDescripcion.Enabled = true;
            }
            else
            {
                h2Form.InnerText = "Detalle de Artículo";
                btnAceptar.Visible = false;
                btnCancelar.Text = "Volver";
                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                ddlCategoria.Enabled = false;
                ddlMarca.Enabled = false;
                txtPrecio.Enabled = false;
                txtDescripcion.Enabled = false;

            }
                
                

            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                string id = Request.QueryString["id"] !=null? Request.QueryString["id"].ToString() : "" ;
                if(id != "" & !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    Session.Add("articuloSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado .Marca.Id.ToString();

                    txtImagenUrl.Text = seleccionado.UrlImagen;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaArticulos.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Descripcion = txtDescripcion.Text;    
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);


                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                    negocio.agregar(nuevo);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}