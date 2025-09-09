using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using CapaDominio;
using CapaNegocio;
using CapaDatos;
using System.Data;

namespace CapaNegocio

{
    public class CatalogoNegocio
    {
        public List<Catalogo> listar(string id ="")
        {
            List<Catalogo> lista = new List<Catalogo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader comandoLector;
            try
            {
              

                conexion.ConnectionString = "server=MAE-2024-\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion MARCA, c.Descripcion Categoria, A.IdMarca, A.IdCategoria, A.Id\r\nfrom ARTICULOS A, MARCAS M, CATEGORIAS C\r\nwhere M.Id = A.IdMarca\r\nand C.Id = A.IdCategoria ";
                comando.Connection = conexion;
                if (id != "")
                    comando.CommandText += " and A.Id = " + id;

                comando.Connection = conexion;

                conexion.Open();
                comandoLector = comando.ExecuteReader();

                while (comandoLector.Read())
                {
                    Catalogo auxiliar = new Catalogo();

                    auxiliar.Id = (int)comandoLector["Id"];
                    auxiliar.Codigo = (string)comandoLector["Codigo"];
                    auxiliar.Nombre = (string)comandoLector["Nombre"];
                    auxiliar.Descripcion = (string)comandoLector["Descripcion"];
                    auxiliar.ImagenUrl = (string)comandoLector["ImagenUrl"];
                    auxiliar.Precio = (decimal)comandoLector["Precio"];
                   

                    if (!(comandoLector["ImagenUrl"] is DBNull))
                        auxiliar.ImagenUrl = (string)comandoLector["ImagenUrl"];

                    auxiliar.marca = new MARCA();
                    auxiliar.marca.Id = (int)comandoLector["Idmarca"];
                    auxiliar.marca.Descripcion = (string)comandoLector["marca"];
                    auxiliar.categoria = new CATEGORIA();
                    auxiliar.categoria.Id = (int)comandoLector["IdCategoria"];
                    auxiliar.categoria.Descripcion = (string)comandoLector["Categoria"];

                    lista.Add(auxiliar);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void Agregar(Catalogo nuevo)
        {
            CapaDatos.AccesoDatos datos = new CapaDatos.AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria, ImagenUrl) values ('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "', " + nuevo.Precio + ", @IdMarca, @IdCategoria, @ImagenUrl)");
                datos.SetearParametro("@IdMarca", nuevo.marca.Id);
                datos.SetearParametro("@IdCategoria", nuevo.categoria.Id);
                datos.SetearParametro("@ImagenUrl", nuevo.ImagenUrl);
                datos.SetearParametro("@Precio", nuevo.Precio);
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
        public void Modificar(Catalogo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @Idmarca, IdCategoria = @Idcate, ImagenUrl = @Imagen, Precio = @Precio where Id = @Id");
                datos.SetearParametro("@Codigo", modificar.Codigo);
                datos.SetearParametro("@Nombre", modificar.Nombre);
                datos.SetearParametro("@Descripcion", modificar.Descripcion);
                datos.SetearParametro("@Idmarca", modificar.marca.Id);
                datos.SetearParametro("@Idcate", modificar.categoria.Id);
                datos.SetearParametro("@Imagen", modificar.ImagenUrl);
                datos.SetearParametro("@Precio", modificar.Precio);
                datos.SetearParametro("@Id", modificar.Id);

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
        public void Eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetearConsulta("delete from ARTICULOS where id=@id");
                datos.SetearParametro("@id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Catalogo> filtrar(string campo, string criterio, string filtro)
        {
            List<Catalogo> lista = new List<Catalogo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion MARCA, c.Descripcion Categoria, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria and ";
                if (campo == "Precio")
                {
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

                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;

                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }

                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;

                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.ComandoLector.Read())
                {
                    Catalogo auxiliar = new Catalogo();

                    auxiliar.Id = (int)datos.ComandoLector["Id"];
                    auxiliar.Codigo = (string)datos.ComandoLector["Codigo"];
                    auxiliar.Nombre = (string)datos.ComandoLector["Nombre"];
                    auxiliar.Descripcion = (string)datos.ComandoLector["Descripcion"];
                    auxiliar.ImagenUrl = (string)datos.ComandoLector["ImagenUrl"];
                    auxiliar.Precio = (decimal)datos.ComandoLector["Precio"];


                    if (!(datos.ComandoLector["ImagenUrl"] is DBNull))
                        auxiliar.ImagenUrl = (string)datos.ComandoLector["ImagenUrl"];

                    auxiliar.marca = new MARCA();
                    auxiliar.marca.Id = (int)datos.ComandoLector["Idmarca"];
                    auxiliar.marca.Descripcion = (string)datos.ComandoLector["marca"];
                    auxiliar.categoria = new CATEGORIA();
                    auxiliar.categoria.Id = (int)datos.ComandoLector["IdCategoria"];
                    auxiliar.categoria.Descripcion = (string)datos.ComandoLector["Categoria"];

                    lista.Add(auxiliar);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
