using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using CapaDominio;
using CapaDatos;
using CapaNegocio;

namespace CapaNegocio
{
    public class MarcaNegocio
    {
        public List<MARCA> listar()
        {
            List<MARCA> lista = new List<MARCA>();
            CapaDatos.AccesoDatos datos = new CapaDatos.AccesoDatos();

            try
            {
                datos.SetearConsulta("select id, Descripcion from MARCAS");
                datos.EjecutarLectura();

                while (datos.ComandoLector.Read())
                {
                    MARCA aux = new MARCA();
                    aux.Id = (int)datos.ComandoLector["Id"];
                    aux.Descripcion = (string)datos.ComandoLector["Descripcion"];

                    lista.Add(aux);

                }


                return lista;
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
