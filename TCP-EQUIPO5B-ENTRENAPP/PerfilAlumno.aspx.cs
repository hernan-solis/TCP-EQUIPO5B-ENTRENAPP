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
        protected void Page_Load(object sender, EventArgs e)
        {
            // TENGO QUE TENER PREVIAMENTE EL ID DEL ALUMNO O USUARIO O EL OBJETO ALUMNO

            // EN ESTE CASO DIGAMOS QUE TENGO EL ID DEL ALUMNO

            int alumnoId = 3; // Reemplazar con el ID real del alumno

            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                
            Alumno alumno = alumnoNegocio.ObtenerPorId(alumnoId);  // obtengo el objeto Alumno

            RutinaNegocio rutinaNegocio = new RutinaNegocio();

            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno(alumnoId); // obtengo la rutina del alumno

            RepeaterDia.DataSource = rutina.Dia; // asigno la lista de dias de la rutina al Repeater

            RepeaterDia.DataBind(); // vinculo los datos al Repeater




        }

        // FUNCION QUE SE EJECUTA CADA VEZ QUE SE VINCULA UN ITEM EN EL REPEATER DE DIAS
        // EN ESTA FUNCION VAMOS A VINCULAR EL REPEATER DE EJERCICIOS ASIGNADOS PARA CADA DIA
        // ES UNA MAMUSHCA, REPETEAR DENTRO DE CADA ITEM DEL REPEATER.
        protected void RepeaterDia_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Dia dia = (Dia)e.Item.DataItem;

                var repeaterEj = (Repeater)e.Item.FindControl("RepeaterEjerAsig");
                repeaterEj.DataSource = dia.EjerciciosAsignados;
                repeaterEj.DataBind();
            }
        }
    }
}