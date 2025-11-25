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

            Alumno alumno = alumnoNegocio.ObtenerPorId((int)ViewState["idAlu"]);
            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno((int)ViewState["idAlu"]);

            //EXPRESION LAMBDA PARA ENCONTRAR EL DIA SELECCIONADO SEGUN EL ID TRAIDO POR PARAMETRO
            //LO USA EL PROFE EN UNO DE SUS VIDEOS
            //Una lambda es una función sin nombre, escrita en una línea, usando la flecha
            //FIND ES UNA FUNCION DE LOS OBJETOS LISTA

            Dia diaSeleccionado = rutina.Dia.Find(d => d.Id == (int)ViewState["idDia"]);

          

            // SETEO EL REPEATER CON LOS EJERCICIOS ASIGNADOS AL DIA SELECCIONADO
            if (!IsPostBack)
            {
                RepeaterEjerciciosAsignados.DataSource = diaSeleccionado.EjerciciosAsignados;
                RepeaterEjerciciosAsignados.DataBind();

                RepeaterEjerAlu.DataSource = diaSeleccionado.EjerciciosAsignados;
                RepeaterEjerAlu.DataBind();
            }

            // SETEO PARA MOSTRAR EL NOMBRE DEL DIA Y LOS TITULOS - TAMBIEN VISIBILIDAD DEL BTN

            string completado = "";
            if (diaSeleccionado.Completado)
            {
                completado = "✅ Completado";
                BtnDiaCompletado.Enabled = false;
                BtnDiaCompletado.Text = "COMPLETADO";
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

        protected void BtnDiaCompletado_Click(object sender, EventArgs e)
        {
            // RECUPERO DATOS DE VIEWSTATE PARA TRABAJAR
            int idDia = (int)ViewState["idDia"];
            int idAlu = (int)ViewState["idAlu"];

            // OBTENGO EL OBJETO ALUMNO Y RUTINA PARA USARLOS COMO PREFIERA.

            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
            RutinaNegocio rutinaNegocio = new RutinaNegocio();

            Alumno alumno = alumnoNegocio.ObtenerPorId((int)ViewState["idAlu"]);
            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno((int)ViewState["idAlu"]);

            //EXPRESION LAMBDA PARA ENCONTRAR EL DIA SELECCIONADO SEGUN EL ID TRAIDO POR PARAMETRO
            //LO USA EL PROFE EN UNO DE SUS VIDEOS
            //Una lambda es una función sin nombre, escrita en una línea, usando la flecha
            //FIND ES UNA FUNCION DE LOS OBJETOS LISTA

            Dia diaACompletar = rutina.Dia.Find(d => d.Id == (int)ViewState["idDia"]);

            // Identifica qué botón específico fue presionado de la lista.
            Button boton = (Button)sender;

            // Encuentra la fila completa(GridViewRow o RepeaterItem) que contiene ese botón
            // o lo buscado con find.
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxSeriesRep = (TextBox)contenedor.FindControl("tbxSeriesRep");
            TextBox tbxRepeticionesRep = (TextBox)contenedor.FindControl("tbxRepeticionesRep");
            TextBox tbxPesoRep = (TextBox)contenedor.FindControl("tbxPesoRep");
            TextBox tbxObservacionesRep = (TextBox)contenedor.FindControl("tbxObservacionesRep");

            // ASIGNO LOS VALORES AL OBJETO DIA A COMPLETAR

            Dia diaCompletado = diaACompletar;
            diaCompletado.Completado = true;

            // RECORRO EL REPEATER CON EL HIDDE FIELD PARA ASIGNAR LOS VALORES DE CADA EJERCICIO ASIGNADO

            int indice = 0;
            foreach (RepeaterItem item in RepeaterEjerAlu.Items)
            {
      
                // Recuperar los TextBox de esa fila
                TextBox tbxSeries = (TextBox)item.FindControl("tbxSeriesRep");
                TextBox tbxReps = (TextBox)item.FindControl("tbxRepeticionesRep");
                TextBox tbxPeso = (TextBox)item.FindControl("tbxPesoRep");
                TextBox tbxObs = (TextBox)item.FindControl("tbxObservacionesRep");

                diaCompletado.EjerciciosAsignados[indice].Series = int.Parse(tbxSeries.Text);
                diaCompletado.EjerciciosAsignados[indice].Repeticiones = int.Parse(tbxReps.Text);

                diaCompletado.EjerciciosAsignados[indice].Peso = decimal.Parse(tbxPeso.Text);

                diaCompletado.EjerciciosAsignados[indice].Observaciones = tbxObs.Text;

                indice++;
            }


            // LLAMO AL NEGOCIO PARA CARGAR HISTORIAL - CONFIRMACION ES POR JS

            HistorialNegocio historialNegocio = new HistorialNegocio(); 
            historialNegocio.AgregarDiaCompletado(diaCompletado);

            // Guardar mensaje de éxito en Session para mostrar después del redirect
            Session["MensajeExito"] = "Dia Completado! Seguí así.. ";

        
            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaAlumno.aspx?idDia={idDia}&idAlu={idAlu}");
        }
    }
}