using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RutinaNegocio
    {
       
            public List<Rutina> Listar()
            {

                List<Rutina> lista = new List<Rutina>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("select ID, UsuarioID, ProfesorID, Título, Descripción from Rutinas");
                    datos.ejecutarLectura();
                    AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                    ProfesorNegocio profesorNegocio = new ProfesorNegocio();
                    DiaNegocio diaNegocio = new DiaNegocio();

                    while (datos.Lector.Read())
                    {
                    
                        Rutina aux = new Rutina();
                        aux.Id = (int)datos.Lector["ID"];
                        aux.Alumno = alumnoNegocio.ObtenerPorId((int)datos.Lector["UsuarioID"]);
                        aux.Profesor = profesorNegocio.ObtenerProfesorPorId((int)datos.Lector["ProfesorID"]);
                        aux.Titulo = (string)datos.Lector["Título"];
                        aux.Descripcion = (string)datos.Lector["Descripción"];
                        aux.Dia = diaNegocio.ListarPorId((int)datos.Lector["ID"]);    

                        lista.Add(aux);

                    
                    }

                    return lista;
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
