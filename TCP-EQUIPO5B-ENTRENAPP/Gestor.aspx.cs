using Business;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

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

            /////////

            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();

            // OBTENGO LA LISTA DE Alumnos
            List<Alumno> listaAlumnos = alumnoNegocio.Listar();

            // ORDENO POR APELLIDO Y NOMBRE USANDO LAMBDA
            // EL PROFE LO USA EN UNO DE LOS VIDEOS
            listaAlumnos = listaAlumnos.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre).ToList();



            // Solo si no es postback, cargo el Repeater de dias, sino se rompe.
            if (!IsPostBack)
            {
                rptGestorProfesor.DataSource = listaProfesores;
                rptGestorProfesor.DataBind();

                //////

                rptGestorAlumno.DataSource = listaAlumnos;
                rptGestorAlumno.DataBind();

            }

        }



        protected void BtnEditarProfesor_Command(object sender, CommandEventArgs e)
        {
            // Recuperar el ID del profesor desde el CommandArgument
            int idProfesor = int.Parse(e.CommandArgument.ToString());



            // Busco el profesor a editar
            ProfesorNegocio profesorNegocio = new ProfesorNegocio();
            Profesor profesor = profesorNegocio.ObtenerProfesorPorId(idProfesor);


            // Obtener el botón y el repeater item de forma directa
            Button boton = (Button)sender;
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxNombre = (TextBox)contenedor.FindControl("tbxNombre");
            TextBox tbxApellido = (TextBox)contenedor.FindControl("tbxApellido");
            TextBox tbxEmail = (TextBox)contenedor.FindControl("tbxEmail");
            TextBox tbxTelefono = (TextBox)contenedor.FindControl("tbxTelefono");
            TextBox tbxEdad = (TextBox)contenedor.FindControl("tbxEdad");
            DropDownList ddlStatus = (DropDownList)contenedor.FindControl("ddlStatus");

            // ASIGNO LOS VALORES AL OBJETO PROFESOR


            profesor.Nombre = tbxNombre.Text;
            profesor.Apellido = tbxApellido.Text;
            profesor.Email = tbxEmail.Text;
            profesor.Telefono = tbxTelefono.Text;


            if (tbxEdad.Text != "")
            {
                profesor.Edad = int.Parse(tbxEdad.Text);
            }
            else
            {
                profesor.Edad = 0;
            }

            if (ddlStatus.SelectedValue != "")
            {
                profesor.Status = bool.Parse(ddlStatus.SelectedValue);
            }
            else
            {
                profesor.Status = true;
            }


            // PREGUNTO AL USUARIO Y SI ESTA OK CON JS Y AGREGO;
            profesorNegocio.Modificar(profesor);


            // Guardar mensaje de éxito en Session para mostrar después del redirect
            Session["MensajeExito"] = "Profesor editado correctamente";

            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/Gestor");


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
        protected void BtnAgregarProfesor_Command(object sender, CommandEventArgs e)
        {

            // Creo el Profesor para asignarle los valores
            ProfesorNegocio profesorNegocio = new ProfesorNegocio();
            Profesor profesor = new Profesor();

            // Obtener el botón y el repeater item de forma directa
            Button boton = (Button)sender;
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxNombreAgregar = (TextBox)contenedor.FindControl("tbxNombreAgregar");
            TextBox tbxApellidoAgregar = (TextBox)contenedor.FindControl("tbxApellidoAgregar");
            TextBox tbxEmailAgregar = (TextBox)contenedor.FindControl("tbxEmailAgregar");
            TextBox tbxTelefonoAgregar = (TextBox)contenedor.FindControl("tbxTelefonoAgregar");
            TextBox tbxEdadAgregar = (TextBox)contenedor.FindControl("tbxEdadAgregar");
            DropDownList ddlStatusAgregar = (DropDownList)contenedor.FindControl("ddlStatusAgregar");


            profesor.Nombre = tbxNombreAgregar.Text;
            profesor.Apellido = tbxApellidoAgregar.Text;
            profesor.Email = tbxEmailAgregar.Text;
            profesor.Contrasenia = tbxTelefonoAgregar.Text;
            profesor.Rol = "Profesor";
            profesor.Telefono = tbxTelefonoAgregar.Text;


            if (tbxEdadAgregar.Text != "")
            {
                profesor.Edad = int.Parse(tbxEdadAgregar.Text);
            }
            else
            {
                profesor.Edad = 0;
            }

            if (ddlStatusAgregar.SelectedValue != "")
            {
                profesor.Status = bool.Parse(ddlStatusAgregar.SelectedValue);
            }
            else
            {
                profesor.Status = true;
            }

            // PREGUNTO AL USUARIO Y SI ESTA OK CON JS Y AGREGO;
            profesorNegocio.Agregar(profesor);


            // Guardar mensaje de éxito en Session para mostrar después del redirect
            Session["MensajeExito"] = "Profesor agregado correctamente";

            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/Gestor");

        }

        //VALIDA FORMATO FECHA Y QUE SEA UNA FECHA QUE EXISTA
        protected void cvFechaFinSuscripcion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // El formato que queremos validar: Año (4 dígitos) / Mes (2 dígitos) / Día (2 dígitos)
            string formatoFecha = "yyyy/MM/dd";
            DateTime fechaValidada;

            // Intentamos convertir el texto de entrada con el formato exacto.
            // TryParseExact es lo que verifica el formato y la validez de la fecha (ej. no permite 2025/02/30)
            bool esFechaValida = DateTime.TryParseExact(
                args.Value, // El texto ingresado por el usuario
                formatoFecha,
                CultureInfo.InvariantCulture, //para evitar problemas regionales
                DateTimeStyles.None,
                out fechaValidada // Se guarda la fecha si es exitosa
            );

            // Si la conversión es exitosa y el formato es el correcto:
            if (esFechaValida)
            {                
                args.IsValid = true; // Indica que la validación fue exitosa
            }
            else
            {
                args.IsValid = false; // Indica que la validación falló
            }
        }

        ////

        protected void BtnEditarAlumno_Command(object sender, CommandEventArgs e)
        {

            // Recuperar el ID del Alumno desde el CommandArgument
            int idAlumno = int.Parse(e.CommandArgument.ToString());



            // Busco el Alumno a editar
            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
            Alumno alumno = alumnoNegocio.ObtenerPorId(idAlumno);


            // Obtener el botón y el repeater item de forma directa
            Button boton = (Button)sender;
            Control contenedor = boton.NamingContainer;

            // Obtener otros valores directamente de los controles
            TextBox tbxNombreAlumno = (TextBox)contenedor.FindControl("tbxNombreAlumno");
            TextBox tbxApellidoAlumno = (TextBox)contenedor.FindControl("tbxApellidoAlumno");
            TextBox tbxEmailAlumno = (TextBox)contenedor.FindControl("tbxEmailAlumno");
            TextBox tbxFechaFinSuscripcion = (TextBox)contenedor.FindControl("tbxFechaFinSuscripcion");
            TextBox tbxTelefonoAlumno = (TextBox)contenedor.FindControl("tbxTelefonoAlumno");
            TextBox tbxEdadAlumno = (TextBox)contenedor.FindControl("tbxEdadAlumno");
            DropDownList ddlStatusAlumno = (DropDownList)contenedor.FindControl("ddlStatusAlumno");

            // ASIGNO LOS VALORES AL OBJETO PROFESOR
            

            alumno.Nombre = tbxNombreAlumno.Text;
            alumno.Apellido = tbxApellidoAlumno.Text;
            alumno.Email = tbxEmailAlumno.Text;

            if (tbxFechaFinSuscripcion.Text != "")
            {
                alumno.FechaFinSuscripcion = DateTime.Parse(tbxFechaFinSuscripcion.Text);
            }
            else
            {
                alumno.FechaFinSuscripcion = DateTime.MinValue; // Asigna 01/01/0001
            }

            alumno.Telefono = tbxTelefonoAlumno.Text;


            if (tbxEdadAlumno.Text != "")
            {
                alumno.Edad = int.Parse(tbxEdadAlumno.Text);
            }
            else
            {
                alumno.Edad = 0;
            }

            if (ddlStatusAlumno.SelectedValue != "")
            {
                alumno.Status = bool.Parse(ddlStatusAlumno.SelectedValue);
            }
            else
            {
                alumno.Status = true;
            }


            // PREGUNTO AL USUARIO Y SI ESTA OK CON JS Y AGREGO;
            alumnoNegocio.Modificar(alumno);


            // Guardar mensaje de éxito en Session para mostrar después del redirect
            Session["MensajeExito"] = "Alumno editado correctamente";

            // REDIRIJO A LA MISMA PAGINA MANTENIENDO LOS DATOS PARA REFRESCAR LA PAGINA CON LOS DATOS NUEVOS
            Response.Redirect($"/Gestor");
            
        }

        protected void BtnEliminarAlumno_Command(object sender, CommandEventArgs e)
        {
            /*
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
            */
        }
    }
}

