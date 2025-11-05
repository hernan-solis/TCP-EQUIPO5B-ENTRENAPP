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
            /*
            EjercicioAsignadoNegocio ejercicioAsignadoNegocio = new EjercicioAsignadoNegocio();

            List<EjercicioAsignado> lista = ejercicioAsignadoNegocio.Listar();

            */

            DiaNegocio diaNegocio = new DiaNegocio();
            List<Dia> listaDias = diaNegocio.Listar();





            //cuando guardeemos datos nuevos siempre tienen que tener algun valor, no vale nulos. 
            // Desde el lado del front;


        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
           

            int idUsuario = negocio.Loguear(EmailLogin.Text, ConstraseniaLogin.Text);

            if (idUsuario > 0 )
            {
                Response.Redirect("~/PerfilAlumno.aspx");

                Profesor profesor = new Profesor();
            
            }
        }
    }
}