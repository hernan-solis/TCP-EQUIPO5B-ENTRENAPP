using Business;
using Models;
using System;
using System.Collections.Generic;
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



            // Solo si no es postback, cargo el Repeater de dias, sino se rompe.
            if (!IsPostBack)
            {
                rptGestorProfesor.DataSource = listaProfesores;
                rptGestorProfesor.DataBind();

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
    }
}
