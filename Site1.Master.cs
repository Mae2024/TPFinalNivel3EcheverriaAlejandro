using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using CapaDominio;

namespace TPFinalNivel3EcheverríaAlejandro
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Registro || Page is Home))
            {
                if (!Seguridad.SessionActiva(Session["user"]))
                    Response.Redirect("Login.aspx", false);
            }
            if (Seguridad.SessionActiva(Session["user"]))
                imgPequeña.ImageUrl = "~/ImagenesPerfil/" + ((USERS)Session["user"]).UrlImagen;
            else
                imgPequeña.ImageUrl = "https://tse1.mm.bing.net/th/id/OIP.t75oQHR4WMinflcpcBlXSQHaFT?rs=1&pid=ImgDetMain&o=7&rm=3";




        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}