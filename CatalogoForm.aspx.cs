using CapaDatos;
using CapaDominio;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3EcheverríaAlejandro
{
    public partial class CatalogoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    List<CATEGORIA> lista = negocio.listar();

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    MarcaNegocio negocion = new MarcaNegocio();
                    List<MARCA> mARCAs = negocion.listar();

                    ddlMarca.DataSource = mARCAs;
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" & !IsPostBack)
                {
                    CatalogoNegocio negocio = new CatalogoNegocio();
                    List<Catalogo> lista = negocio.listar(id);
                    Catalogo seleccionado = lista[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlCategoria.SelectedValue = seleccionado.categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.marca.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);



                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }



        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgCatalogo.ImageUrl = txtImagenUrl.Text;
        }


        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
            try
            {
                Catalogo nuevo = new Catalogo();
                CatalogoNegocio negocio = new CatalogoNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.categoria = new CATEGORIA();
                nuevo.categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.marca = new MARCA();
                nuevo.marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.Modificar(nuevo);
                }
                else
                    negocio.Agregar(nuevo);


                Response.Redirect("CatalogoLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoNegocio negocio = new CatalogoNegocio();
                negocio.Eliminar(int.Parse(txtId.Text));
                Response.Redirect("CatalogoLista.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}