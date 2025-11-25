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
            //  Restaura scroll si existe
            if (Session["ScrollY"] != null && !IsPostBack)
            {
                string script = $"window.scrollTo(0, {Session["ScrollY"]});";
                ClientScript.RegisterStartupScript(this.GetType(), "RestoreScroll", script, true);
                Session["ScrollY"] = null;
            }


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

            // Mostrar mensajes de éxito
            if (!IsPostBack && Session["MensajeExito"] != null)
            {
                string mensaje = Session["MensajeExito"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "success", $"alert('{mensaje}');", true);
                Session.Remove("MensajeExito");
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


            // SETEO LOS TITULOS
            HTresNombreAlumno.InnerText = "Alumno: " + alumno.Apellido + " " + alumno.Nombre;
            HTresNombreRutina.InnerText = "Rutina Titulo: " + rutina.Titulo;
            HTresDescripRutina.InnerText = "Descripción: " + rutina.Descripcion;


            // Recuperar Scroll desde cookie
            if (Request.Cookies["ScrollY"] != null)
            {
                Session["ScrollY"] = Request.Cookies["ScrollY"].Value;
            }



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

                // ENCONTRAR EL DROPDOWNLIST DENTRO DE ESTE ÍTEM ESPECÍFICO
                DropDownList ddlEjercicios = (DropDownList)e.Item.FindControl("DdlEjercicios");

                // OBTENGO LA LISTA DE EJERCICIOS BASE PARA USARLOS LUEGO
                EjercicioBaseNegocio ejercicioNegocio = new EjercicioBaseNegocio();

                List<EjercicioBase> listaEjerciciosBase = ejercicioNegocio.Listar();

                // EL OBJETO QUE DEVUELVE FINDCONTROL ES EN MINUSCULA
                ddlEjercicios.DataSource = listaEjerciciosBase;
                ddlEjercicios.DataTextField = "Nombre";
                ddlEjercicios.DataValueField = "Id";
                ddlEjercicios.DataBind();


            }

        }

        protected void BtnAgregarEjercicioAsignado_Command(object sender, CommandEventArgs e)
        {
            // Recuperar el ID del día desde el CommandArgument
            int idDia = int.Parse(e.CommandArgument.ToString());

            // Recuperar los otros IDs desde el ViewState
            int idAlu = (int)ViewState["idAlu"];
            int idProfe = (int)ViewState["idProfe"];

            // Creo el EjercicioAsignado para asignarle los valores

            EjercicioAsignado ejercicioAsignado = new EjercicioAsignado();

            // Identifica qué botón específico fue presionado de la lista.
            Button boton = (Button)sender;

            // Encuentra la fila completa(GridViewRow o RepeaterItem) que contiene ese botón
            // o lo buscado con find.
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxSeries = (TextBox)contenedor.FindControl("tbxSeries");
            TextBox tbxRepeticiones = (TextBox)contenedor.FindControl("tbxRepeticiones");
            TextBox tbxDescanso = (TextBox)contenedor.FindControl("tbxDescanso");
            TextBox tbxPeso = (TextBox)contenedor.FindControl("tbxPeso");
            TextBox tbxObservaciones = (TextBox)contenedor.FindControl("tbxObservaciones");
            TextBox tbxUrl = (TextBox)contenedor.FindControl("tbxUrl");

            DropDownList ddlEjercicios = (DropDownList)contenedor.FindControl("DdlEjercicios");



            // ASIGNO LOS VALORES AL OBJETO EJERCICIO ASIGNADO
            if (tbxSeries.Text != "")
            {
                ejercicioAsignado.Series = int.Parse(tbxSeries.Text);
            }
            else
            {
                ejercicioAsignado.Series = 0;
            }

            if (tbxRepeticiones.Text != "")
            {
                ejercicioAsignado.Repeticiones = int.Parse(tbxRepeticiones.Text);
            }
            else
            {
                ejercicioAsignado.Repeticiones = 0;
            }

            if (tbxDescanso.Text != "")
            {
                ejercicioAsignado.TiempoEstimado = int.Parse(tbxDescanso.Text);
            }
            else
            {
                ejercicioAsignado.TiempoEstimado = 0;
            }

            if (tbxPeso.Text != "")
            {
                ejercicioAsignado.Peso = decimal.Parse(tbxPeso.Text);
            }
            else
            {
                ejercicioAsignado.Peso = 0;
            }
            ejercicioAsignado.Observaciones = tbxObservaciones.Text;
            ejercicioAsignado.Url = tbxUrl.Text;

            // OBTENGO EL EJERCICIO BASE SELECCIONADO EN EL DROPDOWN
            EjercicioBaseNegocio ejercicioBaseNegocio = new EjercicioBaseNegocio();
            ejercicioAsignado.EjercicioBase = ejercicioBaseNegocio.ObtenerPorId(int.Parse(ddlEjercicios.SelectedValue));

            EjercicioAsignadoNegocio ejercicioAsignadoNegocio = new EjercicioAsignadoNegocio();

            // PREGUNTO AL USUARIO Y SI ESTA OK CON JS Y AGREGO;
            ejercicioAsignadoNegocio.Agregar(ejercicioAsignado, idDia);

            // Guardar mensaje de éxito en Session para mostrar después del redirect
            Session["MensajeExito"] = "Ejercicio guardado correctamente";

            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaProfesor.aspx?diaId={idDia}&idAlu={idAlu}&idProfe={idProfe}");

        }

        protected void BtnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "IdEjerSeleccionado")
            {
                // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA

                //Recupero el argument
                int idEjercicioAsignadoSeleccionado = int.Parse(e.CommandArgument.ToString());

                //Recupero los IDs desde el ViewState
                int idAlu = (int)ViewState["idAlu"];
                int idProfe = (int)ViewState["idProfe"];

                EjercicioAsignadoNegocio ejercicioAsignadoNegocio = new EjercicioAsignadoNegocio();
                // Eliminar directamente (usa JavaScript en el frontend para confirmar)
                ejercicioAsignadoNegocio.Eliminar(idEjercicioAsignadoSeleccionado);

                // Guardar mensaje de éxito en Session
                Session["MensajeExito"] = "Ejercicio eliminado correctamente";


                // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
                Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");
            }
        }

        protected void BtnEliminarDia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "IdDiaEliminar")
            {
                // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA

                //Recupero el argument
                int idDiaAEliminar = int.Parse(e.CommandArgument.ToString());

                //Recupero los IDs desde el ViewState
                int idAlu = (int)ViewState["idAlu"];
                int idProfe = (int)ViewState["idProfe"];

                DiaNegocio diaNegocio = new DiaNegocio();

                // ELIMINA EL DIA Y LOS EJERCICIOS ASIGNADOS RELACIONADOS A ESE DIA
                diaNegocio.Eliminar(idDiaAEliminar);

                // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
                Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");
            }
        }

        protected void BtnEditarNombreDia_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "IdDiaEditar")
            {
                // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA

                //Recupero el argument
                int idDiaAEditar = int.Parse(e.CommandArgument.ToString());

                //Recupero los IDs desde el ViewState
                int idAlu = (int)ViewState["idAlu"];
                int idProfe = (int)ViewState["idProfe"];

                // Identifica qué botón específico fue presionado de la lista.
                Button boton = (Button)sender;

                // Encuentra la fila completa(GridViewRow o RepeaterItem) que contiene ese botón
                // o lo buscado con find.
                Control contenedor = boton.NamingContainer;

                // Obtener otros valores directamente de los controles
                TextBox tbxNombreDia = (TextBox)contenedor.FindControl("TbxNombreDia");




                // Edita directamente (usa JavaScript en el frontend para confirmar)
                DiaNegocio diaNegocio = new DiaNegocio();
                diaNegocio.CambiarNombre(idDiaAEditar, tbxNombreDia.Text);

                // Guardar mensaje de éxito en Session
                Session["MensajeExito"] = "Nombre Día Editado correctamente";


                // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
                Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");
            }

        }

        protected void BtnAgregarDia_Click(object sender, EventArgs e)
        {

            //Recupero los IDs desde el ViewState
            int idAlu = (int)ViewState["idAlu"];
            int idProfe = (int)ViewState["idProfe"];

            // Trato de traer la rutina del alumno, solo para saber que existe en la DB
            // Si no existe, primero le vamos a crear una rutina vacia al alumno

            RutinaNegocio rutinaNegocio = new RutinaNegocio();
            Rutina rutinaCheck = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlu);

            if (rutinaCheck.Alumno == null) {



                Rutina nuevaRutina = new Rutina();

                nuevaRutina.Alumno = new Alumno();
                nuevaRutina.Alumno.Id = idAlu;
                nuevaRutina.Profesor = new Profesor();
                nuevaRutina.Profesor.Id = idProfe;
                nuevaRutina.Titulo = "Nueva Rutina";
                nuevaRutina.Descripcion = "Agregar Descripcion";


                rutinaNegocio.Agregar(nuevaRutina);

            }

            // Agrega Dia Nuevo Directamente (usa JavaScript en el frontend para confirmar)
            DiaNegocio diaNegocio = new DiaNegocio();

            Dia diaNuevo = new Dia();

            diaNuevo.RutinaId = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlu).Id;
            diaNuevo.Completado = false;
            diaNuevo.NombreDia = "Nuevo Día";


            diaNegocio.Agregar(diaNuevo);

            // Guardar mensaje de éxito en Session
            Session["MensajeExito"] = "Dia Nuevo Agregado correctamente";


            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");

        }

        // METODO PARA GUARDAR LA POSICION DEL SCROLL ANTES DE CARGAR LA PAGINA
        protected override void Render(HtmlTextWriter writer)
        {
            string script = @"
        window.addEventListener('beforeunload', function () {
            var y = window.scrollY;
            document.cookie = 'ScrollY=' + y;
        });
    ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveScroll", script, true);
            base.Render(writer);
        }

  
        protected void BtnEditarNombreRutina_Click(object sender, EventArgs e)
        {
         
            // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA

            //Recupero los IDs desde el ViewState
            int idAlu = (int)ViewState["idAlu"];
            int idProfe = (int)ViewState["idProfe"];

            // Recupero la rutina del alumno para obtener su ID
            RutinaNegocio rutinaNegocio = new RutinaNegocio();

            // Trato de traer la rutina del alumno, solo para saber que existe en la DB
            // Si no existe, primero le vamos a crear una rutina vacia al alumno
            Rutina rutinaCheck = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlu);
            if (rutinaCheck.Alumno == null)
            {

                Rutina nuevaRutina = new Rutina();

                nuevaRutina.Alumno = new Alumno();
                nuevaRutina.Alumno.Id = idAlu;
                nuevaRutina.Profesor = new Profesor();
                nuevaRutina.Profesor.Id = idProfe;
                nuevaRutina.Titulo = "Nueva Rutina";
                nuevaRutina.Descripcion = "Agregar Descripcion";


                rutinaNegocio.Agregar(nuevaRutina);

            }

            // CUPERO LA RUTINA YA ASEGURANDOME QUE EXISTA
            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlu);

            // Identifica qué botón específico fue presionado de la lista.
            Button boton = (Button)sender;

            // Encuentra la fila completa(GridViewRow o RepeaterItem) que contiene ese botón
            // o lo buscado con find.
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxNombreRutina = (TextBox)contenedor.FindControl("TbxNombreRutina");


            // Edita directamente (usa JavaScript en el frontend para confirmar)

            rutinaNegocio.CambiarNombre(rutina.Id, tbxNombreRutina.Text);

            // Guardar mensaje de éxito en Session
            Session["MensajeExito"] = "Nombre Rutina Editado correctamente";


            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");
            
        }

        protected void BtnEditarDescripcionRutina_Click(object sender, EventArgs e)
        {
            // PRIMERO SETEO Y PREPARO LOS ID PARA MANDAR A LA SIGUIENTE PAGINA

            //Recupero los IDs desde el ViewState
            int idAlu = (int)ViewState["idAlu"];
            int idProfe = (int)ViewState["idProfe"];

            // Recupero la rutina del alumno para obtener su ID
            RutinaNegocio rutinaNegocio = new RutinaNegocio();
            
            // Trato de traer la rutina del alumno, solo para saber que existe en la DB
            // Si no existe, primero le vamos a crear una rutina vacia al alumno
            Rutina rutinaCheck = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlu);
            if (rutinaCheck.Alumno == null)
            {



                Rutina nuevaRutina = new Rutina();

                nuevaRutina.Alumno = new Alumno();
                nuevaRutina.Alumno.Id = idAlu;
                nuevaRutina.Profesor = new Profesor();
                nuevaRutina.Profesor.Id = idProfe;
                nuevaRutina.Titulo = "Nueva Rutina";
                nuevaRutina.Descripcion = "Agregar Descripcion";


                rutinaNegocio.Agregar(nuevaRutina);

            }

            // CUPERO LA RUTINA YA ASEGURANDOME QUE EXISTA
            Rutina rutina = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlu);

            // Identifica qué botón específico fue presionado de la lista.
            Button boton = (Button)sender;

            // Encuentra la fila completa(GridViewRow o RepeaterItem) que contiene ese botón
            // o lo buscado con find.
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxDescripcionRutina = (TextBox)contenedor.FindControl("TbxDescripcionRutina");


            // Edita directamente (usa JavaScript en el frontend para confirmar)

            rutinaNegocio.CambiarDescripcion(rutina.Id, tbxDescripcionRutina.Text);

            // Guardar mensaje de éxito en Session
            Session["MensajeExito"] = "Nombre Rutina Editado correctamente";


            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");

        }

        protected void BtnEditar_Command(object sender, CommandEventArgs e)
        {
            // Recuperar el ID del día desde el CommandArgument
            int idEjercicioAEditar = int.Parse(e.CommandArgument.ToString());

            // Recuperar los otros IDs desde el ViewState
            int idAlu = (int)ViewState["idAlu"];
            int idProfe = (int)ViewState["idProfe"];

            // Busco el ejercicio asignado a editar

            EjercicioAsignadoNegocio ejercicioAsignadoNegocio = new EjercicioAsignadoNegocio();

            EjercicioAsignado ejercicioAsignado = ejercicioAsignadoNegocio.BuscarPorId(idEjercicioAEditar);




            // Identifica qué botón específico fue presionado de la lista.
            Button boton = (Button)sender;

            // Encuentra la fila completa(GridViewRow o RepeaterItem) que contiene ese botón
            // o lo buscado con find.
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxSeriesRep = (TextBox)contenedor.FindControl("tbxSeriesRep");
            TextBox tbxRepeticionesRep = (TextBox)contenedor.FindControl("tbxRepeticionesRep");
            TextBox tbxDescansoRep = (TextBox)contenedor.FindControl("tbxTiempoEstimadoRep");
            TextBox tbxPesoRep = (TextBox)contenedor.FindControl("tbxPesoRep");
            TextBox tbxObservacionesRep = (TextBox)contenedor.FindControl("tbxObservacionesRep");
            TextBox tbxUrlRep = (TextBox)contenedor.FindControl("tbxUrlRep");

            // ASIGNO LOS VALORES AL OBJETO EJERCICIO ASIGNADO

            if (tbxSeriesRep.Text != "")
            {
                ejercicioAsignado.Series = int.Parse(tbxSeriesRep.Text);
            }
            else
            {
                ejercicioAsignado.Series = 0;
            }

            if (tbxRepeticionesRep.Text != "")
            {
                ejercicioAsignado.Repeticiones = int.Parse(tbxRepeticionesRep.Text);
            }
            else
            {
                ejercicioAsignado.Repeticiones = 0;
            }

            if (tbxDescansoRep.Text != "")
            {
                ejercicioAsignado.TiempoEstimado = int.Parse(tbxDescansoRep.Text);
            }
            else
            {
                ejercicioAsignado.TiempoEstimado = 0;
            }

            if (tbxPesoRep.Text != "")
            {
                ejercicioAsignado.Peso = decimal.Parse(tbxPesoRep.Text);
            }
            else
            {
                ejercicioAsignado.Peso = 0;
            }

            ejercicioAsignado.Observaciones = tbxObservacionesRep.Text;
            ejercicioAsignado.Url = tbxUrlRep.Text;


            // PREGUNTO AL USUARIO Y SI ESTA OK CON JS Y AGREGO;
            ejercicioAsignadoNegocio.ModificarSinEjercicioBase(ejercicioAsignado);

            // Guardar mensaje de éxito en Session para mostrar después del redirect
            Session["MensajeExito"] = "Ejercicio editado correctamente";

            

            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaProfesor.aspx?idAlu={idAlu}&idProfe={idProfe}");

      


        }
    }
}