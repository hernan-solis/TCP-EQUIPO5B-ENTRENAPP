using Business;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class Gestor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ProfesorNegocio profesorNegocio = new ProfesorNegocio();

            // OBTENGO LA LISTA DE PROFESORES 
            List<Profesor> listaProfesores = profesorNegocio.Listar();

            // ORDENO POR APELLIDO Y NOMBRE USANDO LAMBDA
            // EL PROFE LO USA EN UNO DE LOS VIDEOS
            listaProfesores = listaProfesores.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre).ToList();


            // SETEO EL REPEATER PARA MOSTRAR LA LISTA DE ALUMNOS ACTIVOS DEL PROFE
            // Solo si no es postback, cargo el Repeater de dias, sino se rompe.
            if (!IsPostBack)
            {
                rptGestorProfesor.DataSource = listaProfesores;
                rptGestorProfesor.DataBind();
            }

        }
        protected void BtnEditarProfesor_Command(object sender, CommandEventArgs e)
        {
           
        }
        protected void BtnEliminarProfesor_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "IdProfesor")
            {
                //Recupero el argument
                int idProfe = int.Parse(e.CommandArgument.ToString());

                ProfesorNegocio profesor = new ProfesorNegocio();

                // Eliminar directamente (usa JavaScript en el frontend para confirmar)
               profesor.Eliminar(idProfe);

                // Guardar mensaje de éxito en Session
                Session["MensajeExito"] = "Profesor eliminado correctamente";


                // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
                Response.Redirect($"/Gestor");

            }
        }
    }
}
