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
       
            public List<Rutina> listar()
            {

                List<Rutina> lista = new List<Rutina>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("select ID, UsuarioID, ProfesorID, Título, Descripción from Rutinas");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Rutina aux = new Rutina();
                        aux.Id = (int)datos.Lector["ID"];
                        aux.UsuarioId = (int)datos.Lector["UsuarioID"];
                        aux.ProfesorId = (int)datos.Lector["ProfesorID"];
                        aux.Titulo = (string)datos.Lector["Título"];
                        aux.Descripcion = (string)datos.Lector["Descripción"];

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
