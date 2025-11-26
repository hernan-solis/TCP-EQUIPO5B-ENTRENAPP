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
            HistorialNegocio historialNegocio = new HistorialNegocio();
            List<Historial> listaHistorial = historialNegocio.ListarPorIdRutina(1);

            listaHistorial = listaHistorial.OrderByDescending(x => x.FechaRegistro).ToList();

            if (!IsPostBack)
            {
                rptHistorialAlumno.DataSource = listaHistorial;
                rptHistorialAlumno.DataBind();
            }
        }
    }
}