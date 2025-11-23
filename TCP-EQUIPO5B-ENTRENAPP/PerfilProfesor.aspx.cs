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
        //SE DEBE TENER EL IDPROFE O EL OBJETO PROF O DE LA SESSION CUANDO SE LOGUEA
        int idProfesor = 1; // EN ESTE CASO LO DEJO COMO SI FUERA UAN CONSTANSTE - HAY QUE ARREGLARLO
        protected void Page_Load(object sender, EventArgs e)
        {
            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();

            // OBTENGO LA LISTA DE ALUMNOS ACTIVOS DEL PROFESOR
            List<Alumno> listaAlumnos = alumnoNegocio.ListarPorProfesor(idProfesor);

            // ORDENO POR APELLIDO Y NOMBRE USANDO LAMBDA
            // EL PROFE LO USA EN UNO DE LOS VIDEOS
            listaAlumnos = listaAlumnos.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre).ToList();


            // SETEO EL REPEATER PARA MOSTRAR LA LISTA DE ALUMNOS ACTIVOS DEL PROFE
            // Solo si no es postback, cargo el Repeater de dias, sino se rompe.
            if (!IsPostBack)
            {
                rptAlumnos.DataSource = listaAlumnos;
                rptAlumnos.DataBind();
            }
                
        }

        //Parecido al evento ONCLICK pero sirve para obtener parametro del Repeater antes de activar el evento
        protected void BtnVerRutina_Command(object sender, CommandEventArgs e)
        {
            // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA
            int idAlu = int.Parse(e.CommandArgument.ToString());

            int idProfe = idProfesor;

            // Redirigir con el Id del día y el id del alumno
            Response.Redirect("/RutinaProfesor.aspx?idAlu=" + idAlu + "&idProfe=" + idProfe);


        }
    }
}
