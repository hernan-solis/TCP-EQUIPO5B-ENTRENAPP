using Business;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
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

            // Obtener el botón y el repeater item de forma directa
            System.Web.UI.WebControls.Button boton = (System.Web.UI.WebControls.Button)sender;
            System.Web.UI.Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            System.Web.UI.WebControls.TextBox tbxSeries = (System.Web.UI.WebControls.TextBox)contenedor.FindControl("tbxSeries");
            System.Web.UI.WebControls.TextBox tbxRepeticiones = (System.Web.UI.WebControls.TextBox)contenedor.FindControl("tbxRepeticiones");
            System.Web.UI.WebControls.TextBox tbxDescanso = (System.Web.UI.WebControls.TextBox)contenedor.FindControl("tbxDescanso");
            System.Web.UI.WebControls.TextBox tbxPeso = (System.Web.UI.WebControls.TextBox)contenedor.FindControl("tbxPeso");
            System.Web.UI.WebControls.TextBox tbxObservaciones = (System.Web.UI.WebControls.TextBox)contenedor.FindControl("tbxObservaciones");
            System.Web.UI.WebControls.TextBox tbxUrl = (System.Web.UI.WebControls.TextBox)contenedor.FindControl("tbxUrl");

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

            // PREGUNTO AL USUARIO Y SI ESTA OK LO SUBO A LA DB (TENGO QUE TENER EL USING System.Windows.Forms;

            DialogResult resultado = MessageBox.Show(
             "¿Está seguro que desea guardar el ejercicio asignado?",
             "Confirmar Guardado",
              MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
);
            EjercicioAsignadoNegocio ejercicioAsignadoNegocio = new EjercicioAsignadoNegocio();

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Ejercicio guardado correctamente");

                ejercicioAsignadoNegocio.Agregar(ejercicioAsignado, idDia);

                
            }
            else
            {
                MessageBox.Show("Operación cancelada por el usuario");
            }

            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/RutinaProfesor.aspx?diaId={idDia}&idAlu={idAlu}&idProfe={idProfe}");

        }
    }
}