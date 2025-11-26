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
    public partial class CrearNuevoEjercicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EjercicioBaseNegocio ejercicioBaseNegocio = new EjercicioBaseNegocio();
            List<EjercicioBase> listaEjercicios = ejercicioBaseNegocio.Listar();
            if (!IsPostBack)
            {

                rptListarEjercicios.DataSource = listaEjercicios;
                rptListarEjercicios.DataBind();

            }
        }



        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EjercicioBaseNegocio ejercicioBaseNegocio = new EjercicioBaseNegocio();
                EjercicioBase ejercicioBase = new EjercicioBase();

                ejercicioBase.Nombre = txtNombre.Text;
                ejercicioBase.Descripcion = txtDescripcion.Text;
                ejercicioBase.Url = txtURL.Text;

                ejercicioBaseNegocio.Agregar(ejercicioBase);

                Response.Redirect("/CrearNuevoEjercicio.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}