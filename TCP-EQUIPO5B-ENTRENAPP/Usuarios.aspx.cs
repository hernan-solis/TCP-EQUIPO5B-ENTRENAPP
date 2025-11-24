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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegistrarme_Click(object sender, EventArgs e)
        {
            try
            {

                AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                ProfesorNegocio profesorNegocio = new ProfesorNegocio();
                Alumno alumno = new Alumno();


                alumno.Nombre = txtNombre.Text;
                alumno.Apellido = txtApellido.Text;
                alumno.Email = txtEmail.Text;
                alumno.Contrasenia = txtContrasenia.Text;
                alumno.Telefono = txtTelefono.Text;
                alumno.Edad = int.Parse(txtEdad.Text);
                alumno.FechaFinSuscripcion = DateTime.Now.AddDays(30);
                alumno.Objetivo = txtObjetivos.Text;
                alumno.Genero = txtGenero.Text;
                alumno.DiasDisponibles = txtDiasDisponibles.Text;
                alumno.Lesiones = txtLesiones.Text;
                alumno.CondicionMedica = txtCondicionMedica.Text;
                alumno.Comentarios = txtComentarios.Text;

                int profesor = profesorNegocio.ObtenerProfesorConMenosAlumnos();

                alumnoNegocio.Agregar(alumno, profesor);
                Response.Redirect("/Login.aspx");
            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }


}