using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

namespace Negocio
{

    

    public class UsuarioNegocio
    {

        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into USERS(email, pass) values(@email, @pass)");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
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


        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagen Where Id = @id");
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@imagen", (object)user.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@id", user.Id);
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

        public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from USERS where id = @id");
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

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, email, pass, urlImagenPerfil, nombre, apellido, admin from USERS where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];

                    return true;

                }
                return false;
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

        public bool usuarioExistente(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearConsulta("SELECT * FROM USERS WHERE email = @email");
                datos.setearParametro("@email", usuario.Email);
                datos.ejecutarLectura();



                if (datos.Lector.Read())
                    return true;
                else
                    return false;
                 

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
