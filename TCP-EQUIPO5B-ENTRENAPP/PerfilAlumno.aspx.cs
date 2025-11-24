using Business;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class PerfilAlumno : System.Web.UI.Page
    {
        // TENGO QUE TENER PREVIAMENTE EL ID DEL ALUMNO O USUARIO O EL OBJETO ALUMNO
        // O EL DATO TENERLO EN LA SESSION
        // EN ESTE CASO DIGAMOS QUE TENGO EL ID DEL ALUMNO

        int alumnoId = 3; // Reemplazar con el ID real del alumno  - TRABAJA COMO UNA CONSTANTE
        protected void Page_Load(object sender, EventArgs e)
        {
            

            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                
            Alumno alumno = alumnoNegocio.ObtenerPorId(alumnoId);  // obtengo el objeto Alumno

            RutinaNegocio rutinaNegocio = new RutinaNegocio();

            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno(alumnoId); // obtengo la rutina del alumno

            // Solo si no es postback, cargo el Repeater de dias, sino se rompe.
            if (!IsPostBack) {

                RepeaterDia.DataSource = rutina.Dia; // asigno la lista de dias de la rutina al Repeater

                RepeaterDia.DataBind(); // vinculo los datos al Repeater
            }

            // SETEO EL TITULO CON EL NOMBRE DEL ALUMNO
            HTresNombreAlumno.InnerText = "Rutina de: " + alumno.Apellido + " " + alumno.Nombre;


        }

        // FUNCION QUE SE EJECUTA CADA VEZ QUE SE VINCULA UN ITEM EN EL REPEATER DE DIAS
        // EN ESTA FUNCION VAMOS A VINCULAR EL REPEATER DE EJERCICIOS ASIGNADOS PARA CADA DIA
        // ES UNA MAMUSHCA, REPETEAR DENTRO DE CADA ITEM DEL REPEATER.
        protected void RepeaterDia_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Verificar que el item es un item de datos (no header/footer)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtener el objeto Dia asociado a este item
                Dia dia = (Dia)e.Item.DataItem;

                // Encontrar el Repeater de ejercicios dentro del item actual
                var repeaterEj = (Repeater)e.Item.FindControl("RepeaterEjerAsig");

                // Vincular el Repeater de ejercicios con la lista de ejercicios del día actual
                repeaterEj.DataSource = dia.EjerciciosAsignados;
                repeaterEj.DataBind();
            }
        }

        //Parecido al evento ONCLICK pero sirve para obtener parametro del Repeater antes de activar el evento
        protected void BtnVerRutina_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "VerDia")
            {
                // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA
                int idDia = int.Parse(e.CommandArgument.ToString());

                int idAlu = alumnoId;   

                // Redirigir con el Id del día y el id del alumno
                Response.Redirect("/RutinaAlumno.aspx?idDia=" + idDia + "&idAlu="+ idAlu);
            }
        }
    }
}