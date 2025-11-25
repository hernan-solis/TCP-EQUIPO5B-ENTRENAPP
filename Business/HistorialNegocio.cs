using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HistorialNegocio
    {
        public void AgregarDiaCompletado(Dia diaCompletado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (var ejercicio in diaCompletado.EjerciciosAsignados) {

                    datos.limpiarParametros();

                    datos.setearConsulta("INSERT INTO Historial (RutinaID, FechaRegistro, EjercicioBaseID, Series, Repeticiones, Peso, Observaciones) VALUES (@RutinaID, @FechaRegistro, @EjercicioBaseID, @Series, @Repeticiones, @Peso, @Observaciones)");
                        datos.setearParametro("@RutinaId", diaCompletado.RutinaId);
                        datos.setearParametro("@FechaRegistro", DateTime.Now);
                        datos.setearParametro("@EjercicioBaseID", ejercicio.EjercicioBase.Id);
                        datos.setearParametro("@Series", ejercicio.Series);
                        datos.setearParametro("@Repeticiones", ejercicio.Repeticiones);
                        datos.setearParametro("@Peso", ejercicio.Peso);
                        datos.setearParametro("@Observaciones", ejercicio.Observaciones);
                        

                        datos.ejecutarAccion();
                }

                datos.limpiarParametros();

                datos.setearConsulta("UPDATE Día Set Completado = 1 where ID = @ID");
                datos.setearParametro("@ID", diaCompletado.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
