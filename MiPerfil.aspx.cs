using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaDominio;
using CapaNegocio;

namespace TPFinalNivel3EcheverríaAlejandro
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SessionActiva(Session["user"]))
                    {
                        USERS user = (USERS)Session["user"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;

                        if (!string.IsNullOrEmpty(user.UrlImagen))
                            ImagenNueva.ImageUrl = "~/Images/" + user.UrlImagen;
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        } 
        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            try
            {
                UserNegocio negocio = new UserNegocio();
                USERS user = (USERS)Session["user"];

                if (txtImagen.PostedFile.FileName!="")
                {
                    string camino = Server.MapPath("./ImagenesPerfil/");
                    txtImagen.PostedFile.SaveAs(camino + "Perfil-" + user.Id + ".jpg");
                    user.UrlImagen = "Perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.Actualizar(user);

                Image img = (Image)Master.FindControl("imgPequeña");
                img.ImageUrl = "~/ImagenesPerfil/" + user.UrlImagen;

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());

            }
        }
    }
}