using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDominio;
using CapaDatos;

namespace TPFinalNivel3EcheverríaAlejandro
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Catalogo> ListaCatalogo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogoNegocio negocio = new CatalogoNegocio();
            ListaCatalogo = negocio.listar();
            Repetidor.DataSource = ListaCatalogo;
            Repetidor.DataBind();
        }
    }
}