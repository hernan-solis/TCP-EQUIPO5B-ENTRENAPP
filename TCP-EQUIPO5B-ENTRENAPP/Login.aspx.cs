using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Models;

namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ProfesorNegocio profesorNegocio = new ProfesorNegocio();

            // Profesor profesor = profesorNegocio.ObtenerProfesorPorId(2);

           // RutinaNegocio rutinaNegocio = new RutinaNegocio();

           // Rutina rutina = rutinaNegocio.ObtenerRutinaPorId(1);

            GestorNegocio gestorNegocio = new GestorNegocio();

            var gestores = gestorNegocio.Listar();





        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();

            // CHEQUEAR EL TEMA DEL LOGIN

            

            int idUsuario = negocio.Loguear(EmailLogin.Text, ConstraseniaLogin.Text);

            usuario = negocio.ObtenerUsuarioPorId(idUsuario);

            string rol = usuario.Rol;

            if (idUsuario > 0)
            {
                if (rol == "Profesor")
                {
                    Response.Redirect("~/PerfilProfesor.aspx");

                }
                else if (rol == "Alumno")
                {
                    Response.Redirect("~/PerfilAlumno.aspx");

                }

            }

            
        }
    }
}