using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;


namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class PerfilProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();

            List<Alumno> listaAlumnos = alumnoNegocio.ListarPorProfesor(1);

            rptAlumnos.DataSource = listaAlumnos;
            rptAlumnos.DataBind();

        }

       


    }
}
