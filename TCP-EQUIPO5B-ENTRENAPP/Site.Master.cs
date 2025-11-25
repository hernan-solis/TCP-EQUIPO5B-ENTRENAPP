using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigurarNavbar();
            }
        }

        private void ConfigurarNavbar()
        {
            //  Ocultar según tipo de usuario
            if (Session["TipoUsuario"] != null)
            {
                string tipoUsuario = Session["TipoUsuario"].ToString();

                if (tipoUsuario == "Alumno")
                {
                    liPerfilProfe.Visible = false;      // Ocultar perfil profesor
                    liLogin.Visible = false;            // Ocultar login
                    liCerrarSesion.Visible = true;      // Mostrar cerrar sesión
                }
                else if (tipoUsuario == "Profesor")
                {
                    liPerfilAlumno.Visible = false;     // Ocultar perfil alumno  
                    liLogin.Visible = false;            // Ocultar login
                    liCerrarSesion.Visible = true;      // Mostrar cerrar sesión
                }
                else if (tipoUsuario == "Gestor")
                {
                    liPerfilAlumno.Visible = false;     // Ocultar perfil alumno  
                    liPerfilProfe.Visible = false;      // Ocultar perfil profesor
                    liLogin.Visible = false;            // Ocultar login
                    liCerrarSesion.Visible = true;      // Mostrar cerrar sesión
                }
            }
            else
            {
                // ESTE ELSE SE EJECUTA CUANDO NO HAY SESIÓN
                liPerfilAlumno.Visible = false;
                liPerfilProfe.Visible = false;
                liCerrarSesion.Visible = false;
                liLogin.Visible = true;                 // Mostrar login
            }
        }
    }
}