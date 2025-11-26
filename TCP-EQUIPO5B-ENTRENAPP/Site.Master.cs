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
                    liAlta.Visible = false;             // Ocultar alta
                    liGestor.Visible = false;            // Ocultar gestor
                    liCerrarSesion.Visible = true;
                    liHistorialAlumno.Visible = true;
                    liCrearNuevoEjercicio.Visible = false;// ocultar crear nuevo ejercicico                
                }
                else if (tipoUsuario == "Profesor")
                {
                    liPerfilAlumno.Visible = false;     // Ocultar perfil alumno  
                    liLogin.Visible = false;            // Ocultar login
                    liAlta.Visible = false;              // Ocultar alta
                    liGestor.Visible = false;            // Ocultar gestor
                    liCerrarSesion.Visible = true;      // Mostrar cerrar sesión
                    liHistorialAlumno.Visible = false; // Ocultar historial alumno
                    liCrearNuevoEjercicio.Visible = true;// mostrar crear nuevo ejercicico
                                                        
                }
                else if (tipoUsuario == "Gestor")
                {
                    liPerfilAlumno.Visible = false;     // Ocultar perfil alumno  
                    liPerfilProfe.Visible = false;      // Ocultar perfil profesor
                    liLogin.Visible = false;            // Ocultar login
                    liAlta.Visible = false;              // Ocultar alta
                    liGestor.Visible = true;              // Mostrar gestor
                    liCerrarSesion.Visible = true;      // Mostrar cerrar sesión
                    liHistorialAlumno.Visible = false;
                    liCrearNuevoEjercicio.Visible = true;// mostrar crear nuevo ejercicico

                }
            }
            else
            {
                // ESTE ELSE SE EJECUTA CUANDO NO HAY SESIÓN
                liPerfilAlumno.Visible = false;         // Ocultar perfil Alu
                liPerfilProfe.Visible = false;        // Ocultar perfil Profe  
                liCerrarSesion.Visible = false;       // Ocultar Cerrar Sesion  
                liGestor.Visible = false;            // Ocultar gestor
                liLogin.Visible = true;              // Mostrar login
                liHistorialAlumno.Visible = false;    // Ocultar historial alumno
                liCrearNuevoEjercicio.Visible = false;// ocultar crear nuevo ejercicico 
            }
        }


        protected void LbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpiar toda la sesión
            Session.Clear();        // Limpia todos los valores
            Session.Abandon();      // Abandona la sesión

            // Redirigir al login o home
            Response.Redirect("~/");
        }
    }
}