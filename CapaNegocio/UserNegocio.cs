using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDominio;

namespace CapaNegocio
{
    public class UserNegocio
    {
        public void Actualizar(USERS user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Updates USERS set UrlImagen = @Imagen, Nombre = @Nombre, Apellido = @Apellido where Id = @Id");
                datos.SetearParametro("@Imagen", (Object)user.UrlImagen ?? DBNull.Value);
                datos.SetearParametro("@Nombre", user.Nombre);
                datos.SetearParametro("@Apellido", user.Apellido);
                datos.SetearParametro("@Id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int InsertarNuevo(USERS nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearProcedimiento("InsertarNuevo");
                datos.SetearParametro("@Email", nuevo.Email);
                datos.SetearParametro("@Pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public bool Login(USERS user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select Id, email, pass, nombre, apellido, admin, UrlImagenPerfil from CATALOGO_WEB_DB.dbo.USERS where Email = @email and Pass = @pass");
                datos.SetearParametro("@email", user.Email);
                datos.SetearParametro("@pass", user.Pass);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["UrlImagenPerfil"] is DBNull))
                        user.UrlImagen = (string)datos.Lector["UrlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];

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
                datos.CerrarConexion();

            }
        }
    }
}
