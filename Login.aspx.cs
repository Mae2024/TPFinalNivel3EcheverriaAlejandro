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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            USERS user = new USERS();
            UserNegocio negocio = new UserNegocio();
            try
            {
                user.Email = txtEmail.Text;
                user.Pass = txtContraseña.Text;
                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("MiPerfil.aspx", false);

                }
                else
                {
                    Session.Add("Error", "user o pass incorrectos");

                }
            }

            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                throw;
            }
        }
    }
}