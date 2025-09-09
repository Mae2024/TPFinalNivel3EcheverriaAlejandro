using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace CapaDatos

{
    public class AccesoDatos
    {
        public SqlConnection conexion;
        public SqlCommand Comando;
        public SqlDataReader ComandoLector;
        public SqlDataReader Lector
        {
            get { return ComandoLector; }   //para acceder a leer desde otra clase
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=MAE-2024-\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            Comando = new SqlCommand();
        }
        public void SetearConsulta(string SetearConsulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = SetearConsulta;
        }
        public void SetearProcedimiento(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;

        }
        public void EjecutarLectura()
        {
            Comando.Connection = conexion;
            conexion.Open();
            ComandoLector = Comando.ExecuteReader();
        }
        public void ejecutarAccion()        //ejecutar Accion metodo no consulta, para insert DB
        {
            Comando.Connection = conexion;
            try
            {
                conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar()        //para que devuelva el entero del id
        {
            Comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(Comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void SetearParametro(string Nombre, Object valor)
        {
            Comando.Parameters.AddWithValue(Nombre, valor);
        }
        public void CerrarConexion()
        {
            if (ComandoLector != null)
                ComandoLector.Close();
            conexion.Close();
        }
    }
}
