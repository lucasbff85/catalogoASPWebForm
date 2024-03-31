using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Codigo, Nombre, M.Descripcion Marca,C.Descripcion Categoria, A.Descripcion,  Precio, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id=A.IdMarca and C.Id=A.IdCategoria and Precio>0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    
                    aux.Precio = Math.Round(Convert.ToDecimal(datos.Lector["Precio"]), 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    

                    lista.Add(aux);
                }

                
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public List<Articulo> listarSuspendidos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Codigo, Nombre, M.Descripcion Marca,C.Descripcion Categoria, A.Descripcion,  Precio, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id=A.IdMarca and C.Id=A.IdCategoria and Precio<=0");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = Math.Round(Convert.ToDecimal(datos.Lector["Precio"]), 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria, ImagenUrl) values ('"+nuevo.Codigo +"', '"+nuevo.Nombre+"', @Descripcion, @Precio, @idMarca, @idCategoria, @UrlImagen)");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }     
        }

        public void modificar(Articulo modificar) 
        {
            AccesoDatos datos=new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @urlImagen, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marca.Id);
                datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                datos.setearParametro("@urlImagen", modificar.UrlImagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }

        public void modificarPrecio(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Precio = @precio where Id = @id");
                datos.setearParametro("@id", modificar.Id);
                datos.setearParametro("@precio", modificar.Precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Codigo, Nombre, M.Descripcion Marca,C.Descripcion Categoria, A.Descripcion,  Precio, ImagenUrl, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id=A.IdMarca and C.Id=A.IdCategoria and Precio>0 and ";
                switch (campo) 
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;

                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;

                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;

                    case "Marca":
                        consulta += "M.Descripcion = @criterio";
                        datos.setearParametro("@criterio", criterio);
                        break;

                    case "Categoría":
                        consulta += "C.Descripcion = @criterio";
                        datos.setearParametro("@criterio", criterio);
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    
                    aux.Precio = Math.Round(Convert.ToDecimal(datos.Lector["Precio"]), 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void suspender(int id) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Precio=0 where Id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            { 
                datos.cerrarConexion();
            }
        }
    }
}
