using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;

namespace TPFinalNivel3EcheverríaAlejandro
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                USERS user = new USERS();
               UserNegocio usernegocio = new UserNegocio();

                user.Email = txtEmail.Text; 
                user.Pass = txtContraseña.Text;
                user.Id = usernegocio.InsertarNuevo(user);
                Session.Add("user", user);


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}