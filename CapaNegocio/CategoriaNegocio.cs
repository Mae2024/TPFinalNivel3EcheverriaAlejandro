using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriaNegocio
    {
        public List<CATEGORIA> listar()
        {
            List<CATEGORIA> lista = new List<CATEGORIA>();
            CapaDatos.AccesoDatos datos = new CapaDatos.AccesoDatos();

            try
            {
                datos.SetearConsulta("select id, Descripcion from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.ComandoLector.Read())
                {
                    CATEGORIA aux = new CATEGORIA();
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

