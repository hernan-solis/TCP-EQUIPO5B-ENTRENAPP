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
            // OBTENGO EL IDPROFE DE LA URL O DE LA SESSION CUANDO SE LOGUEA - OPERADOR TERNARIO

            int idProfesor = Session["idUsuario"] != null ? (int)Session["idUsuario"] : int.Parse(Request.QueryString["idProfe"]);

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
            // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA / RECUPER EL DATO DEL ARGUMENT
            int idAlu = int.Parse(e.CommandArgument.ToString());

            int idProfesor = Session["idUsuario"] != null ? (int)Session["idUsuario"] : int.Parse(Request.QueryString["idProfe"]);
            int idProfe = idProfesor;

            // Redirigir con el Id del día y el id del alumno igual sigue en la sesion
            Response.Redirect("/RutinaProfesor.aspx?idAlu=" + idAlu + "&idProfe=" + idProfe);


        }
    }
}
