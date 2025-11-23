using Business;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class RutinaProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // PRIMERO RECUPERO LOS ID PASADOS POR PARAMETRO EN LA URL

            if (!IsPostBack)
            {
                // Recuperar parámetros
                string idAluUrl = Request.QueryString["idAlu"];
                string idProfeUrl = Request.QueryString["idProfe"];


                // PEQUEÑO CONTROL DE ERRORES
                if (idProfeUrl == null || idAluUrl == null)
                {
                    Response.Write("Error: faltan parámetros en la URL");
                    return;
                }

                int idProfe = int.Parse(idProfeUrl);
                int idAlu = int.Parse(idAluUrl);

                //Se rompe si siempre llamas a la misma página con los mismos parámetros
                //Solucion: guardar en ViewState
                // Guardar en ViewState para siguientes postbacks //
                // VIEWSTATE ES UN MECANISMO PARA RECORDAD VALORES ENTRE POSTBACKS

                ViewState["idProfe"] = idProfe;
                ViewState["idAlu"] = idAlu;
            }
            else
            {
                // En postbacks, levantar de ViewState
                int idProfe = (int)ViewState["idProfe"];
                int idAlu = (int)ViewState["idAlu"];
            }

            // OBTENGO EL OBJETO ALUMNO Y PROFE Y LA RUTINA DEL ALUMNO PARA USARLOS COMO PREFIERA.

            ProfesorNegocio profesorNegocio = new ProfesorNegocio();
            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
            RutinaNegocio rutinaNegocio = new RutinaNegocio();


            Alumno alumno = alumnoNegocio.ObtenerPorId((int)ViewState["idAlu"]);
            Profesor profesor = profesorNegocio.ObtenerProfesorPorId((int)ViewState["idProfe"]);
            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno(alumno.Id);

            // SETEO EL REPEATER - OJO CON LOS POSTBACKS
            if (!IsPostBack)
            {
                RepeaterDiaAlu.DataSource = rutina.Dia;
                RepeaterDiaAlu.DataBind();
            }
                

            //
            // SETEO EL TITULO CON EL NOMBRE DEL ALUMNO
            HTresNombreAlumno.InnerText = "Gestion de rutina Alumno: " + alumno.Apellido + " " + alumno.Nombre;


        }

        // FUNCION QUE SE EJECUTA CADA VEZ QUE SE VINCULA UN ITEM EN EL REPEATER DE DIAS
        // EN ESTA FUNCION VAMOS A VINCULAR EL REPEATER DE EJERCICIOS ASIGNADOS PARA CADA DIA
        // ES UNA MAMUSHCA, REPETEAR DENTRO DE CADA ITEM DEL REPEATER.
        protected void RepeaterDiaAlu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Verificar que el item es un item de datos (no header/footer)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtener el objeto Dia asociado a este item
                Dia diaActual = (Dia)e.Item.DataItem;

                // Encontrar el Repeater de ejercicios dentro del item actual
                Repeater repeaterEjercicios = (Repeater)e.Item.FindControl("RepeaterEjerAsigDiaAlu");

                // Vincular el Repeater de ejercicios con la lista de ejercicios del día actual
                repeaterEjercicios.DataSource = diaActual.EjerciciosAsignados;
                repeaterEjercicios.DataBind();
            }

        }


    }
}