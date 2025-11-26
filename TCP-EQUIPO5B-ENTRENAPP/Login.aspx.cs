using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Models;

namespace TCP_EQUIPO5B_ENTRENAPP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ocultar el label de error al cargar la pagina
            lblMensajeError.Visible = false;

            //Muestro el lblError si la URL tiene algo luego del Postback

            if (Request.QueryString["error"]!=null) {
                lblMensajeError.Text = Request.QueryString["error"];
                lblMensajeError.Visible = true;
            }

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();

            // VALIDO QUE EXISTA MAIL Y CONTRASEÑA, SINO REDIRECCIONO A LOGIN CON MENSAJE
            // LOGUEAR DEVUELVE EL ID DEL USUARIO SI EXISTE, SINO CERO
            int idUsuario = negocio.Loguear(tbxEmailLogin.Text, tbxConstraseniaLogin.Text);

            //SI TRAE CERO NO EXISTE

            usuario = negocio.ObtenerUsuarioPorId(idUsuario);


            string rol;

            if (idUsuario > 0)
            {
                //  GUARDO EN SESSION ID Y ROL, LUEGO TAMBIEN MANDO POR URL, AMBOS
                rol = usuario.Rol;
                Session["IdUsuario"] = idUsuario;
                Session["TipoUsuario"] = rol;

                switch (rol)
                {
                    case "Profesor":
                        {

                            ProfesorNegocio profesorNegocio = new ProfesorNegocio();
                            Profesor profesor = profesorNegocio.ObtenerProfesorPorId(idUsuario);

                            if (profesor.Status == false)
                            {
                                Response.Redirect("~/Login.aspx?error=Usuario Inactivo, contacte al administrador");
                            }
                            else {
                                Response.Redirect("~/PerfilProfesor.aspx?idProfe=" + idUsuario);
                            }
                                

                            

                        }
                        break;
                    case "Alumno":
                        {
                            AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                            Alumno alumno = alumnoNegocio.ObtenerPorId(idUsuario);

                            if (alumno.FechaFinSuscripcion > DateTime.Now)
                            {
                                Response.Redirect("~/PerfilAlumno.aspx?idAlu=" + idUsuario);
                            }
                            else {
                                Response.Redirect("~/Login.aspx?error=Suscripcion Vencida !!");
                            }
                            
                        }
                        
                        break;
                    case "Gestor":
                        {
                            Response.Redirect("~/Gestor.aspx?idGestor=" + idUsuario);
                        }
                        
                        break;
                    default:
                        Response.Redirect("~/Default.aspx");
                        break;
                }
            }
            else {
                Response.Redirect("~/Login.aspx?error=Email o Contraseña incorrecto");
            }


        }
    }
}