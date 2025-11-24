using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class RutinaAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // PRIMERO RECUPERO LOS ID PASADOS POR PARAMETRO EN LA URL

            if (!IsPostBack)
            {
                // Recuperar parámetros
                string idDiaUrl = Request.QueryString["idDia"];
                string idAluUrl = Request.QueryString["idAlu"];

                // PEQUEÑO CONTROL DE ERRORES
                if (idDiaUrl == null || idAluUrl == null)
                {
                    Response.Write("Error: faltan parámetros en la URL");
                    return;
                }

                int idDia = int.Parse(idDiaUrl);
                int idAlu = int.Parse(idAluUrl);

                

                //Se rompe si siempre llamas a la misma página con los mismos parámetros
                //Solucion: guardar en ViewState
                // Guardar en ViewState para siguientes postbacks //
                // VIEWSTATE ES UN MECANISMO PARA RECORDAD VALORES ENTRE POSTBACKS

                ViewState["idDia"] = idDia;
                ViewState["idAlu"] = idAlu;
            }
            else
            {
                // En postbacks, levantar de ViewState
                int idDia = (int)ViewState["idDia"];
                int idAlu = (int)ViewState["idAlu"];
            }

            // OBTENGO EL OBJETO ALUMNO Y RUTINA PARA USARLOS COMO PREFIERA.

            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
            RutinaNegocio rutinaNegocio = new RutinaNegocio();

            Alumno alumno= alumnoNegocio.ObtenerPorId((int)ViewState["idAlu"]);
            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno((int)ViewState["idAlu"]);

            //EXPRESION LAMBDA PARA ENCONTRAR EL DIA SELECCIONADO SEGUN EL ID TRAIDO POR PARAMETRO
            //LO USA EL PROFE EN UNO DE SUS VIDEOS
            //Una lambda es una función sin nombre, escrita en una línea, usando la flecha
            //FIND ES UNA FUNCION DE LOS OBJETOS LISTA

            Dia diaSeleccionado = rutina.Dia.Find(d => d.Id == (int)ViewState["idDia"]);

            // SETEO EL REPEATER CON LOS EJERCICIOS ASIGNADOS AL DIA SELECCIONADO
            if (!IsPostBack) {
                RepeaterEjerciciosAsignados.DataSource = diaSeleccionado.EjerciciosAsignados;
                RepeaterEjerciciosAsignados.DataBind();
            }


            // SETEO PARA MOSTRAR EL NOMBRE DEL DIA Y LOS TITULOS

            string completado = "";
            if (diaSeleccionado.Completado)
            {
                completado = "✅ Completado";
            }
            else
            {
                completado = "⏳ Pendiente";
            }
            DivTituloDia.InnerText = diaSeleccionado.NombreDia + " - " + completado;
            HTresNombreAlumno.InnerText = alumno.Apellido + " " + alumno.Nombre;
            HTresNombreProfe.InnerText = "Profesor: " + rutina.Profesor.Apellido + " " + rutina.Profesor.Apellido;
            HTresNombreRutina.InnerText = "Rutina: " + rutina.Titulo;
            HTresNombreRutinaDescrip.InnerText = "Descripción: " + rutina.Descripcion;




        }
    }
}