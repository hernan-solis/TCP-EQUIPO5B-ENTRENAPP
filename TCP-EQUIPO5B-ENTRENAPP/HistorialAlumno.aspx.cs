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
    public partial class HistorialAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHistorial();
            }
        }

        private void CargarHistorial()
        {
            int idRutina = ObtenerIdRutinaDelAlumnoLogueado();

            if (idRutina > 0)
            {

                HistorialNegocio historialNegocio = new HistorialNegocio();
                List<Historial> listaHistorial = historialNegocio.ListarPorIdRutina(1);

                // Obtenenemos el valor del filtro
                string filtroNombre = tbxFiltroEjercicio.Text.Trim();

                // usar el filtro si se ingresó un valor
                if (!string.IsNullOrEmpty(filtroNombre))
                {
                    // Filtra por el nombre del ejercicio, ignorando mayúsculas/minúsculas y espacios
                    listaHistorial = listaHistorial.Where(x => x.EjercicioBase != null && x.EjercicioBase.Nombre.Trim().ToLower().Contains(filtroNombre.ToLower())).ToList();
                }

                listaHistorial = listaHistorial.OrderByDescending(x => x.FechaRegistro).ToList();

                rptHistorialAlumno.DataSource = listaHistorial;
                rptHistorialAlumno.DataBind();
            }
            else
            {
                rptHistorialAlumno.DataSource = null;
                rptHistorialAlumno.DataBind();
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private int ObtenerIdRutinaDelAlumnoLogueado()
        {
            //OBTENER EL ID DEL ALUMNO DESDE LA SESIÓN
            int idAlumno = 0;
            if (Session["IdUsuario"] != null)
            {
                idAlumno = (int)Session["IdUsuario"];
            }
            // OBTENER LA RUTINA COMPLETA Y OBTENER EL ID
            try
            {
                RutinaNegocio rutinaNegocio = new RutinaNegocio();

                Rutina rutinaDelAlumno = rutinaNegocio.ObtenerRutinaPorIdAlumno(idAlumno);

                if (rutinaDelAlumno != null)
                {
                    return rutinaDelAlumno.Id;
                }
                else
                {
                    throw new Exception("El alumno no tiene una rutina asignada.");
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}