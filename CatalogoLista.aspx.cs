using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using CapaDatos;

namespace TPFinalNivel3EcheverríaAlejandro
{
    public partial class CatalogoLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "se requiere administrador para ingresar");
            }

            FiltroAvanzado = chkFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                CatalogoNegocio negocio = new CatalogoNegocio();
                Session.Add("CatalogoLista", negocio.listar());

                dgvCatalogo.DataSource = Session["CatalogoLista"];
                dgvCatalogo.DataBind();
            }
        }


        protected void dgvCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvCatalogo.SelectedDataKey.Value.ToString();
            Response.Redirect("CatalogoForm.aspx?id=" + id);
        }

        protected void dgvCatalogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCatalogo.PageIndex = e.NewPageIndex;
            dgvCatalogo.DataBind();

        }

        protected void Filtro_TextChanged(object sender, EventArgs e)
        {
            List<Catalogo> lista = (List<Catalogo>)Session["CatalogoLista"];
            List<Catalogo> listaFiltro = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvCatalogo.DataSource = listaFiltro;
            dgvCatalogo.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoNegocio negocio = new CatalogoNegocio();
                dgvCatalogo.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                ddlCriterio.SelectedItem.ToString(), txtFiltroavanzado.Text);
                dgvCatalogo.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)


        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");

            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");

            }
        }
    }
}
