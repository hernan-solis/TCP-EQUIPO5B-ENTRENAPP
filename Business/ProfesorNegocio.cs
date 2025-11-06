using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProfesorNegocio
    {
        public List<Profesor> Listar()
        {

            List<Profesor> lista = new List<Profesor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Teléfono, Edad from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Profesor aux = new Profesor();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Rol = (string)datos.Lector["Rol"];
                    aux.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
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

        //ELIMINACION FISICA, CUIDADO
        public void Eliminar(int id)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarioNegocio.Eliminar(id);
        }

        public string ObtenerNombreCompletoPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string nombreCompleto = string.Empty;
            try
            {
                datos.setearConsulta("SELECT Nombre, Apellido FROM Usuarios WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    string nombre = (string)datos.Lector["Nombre"];
                    string apellido = (string)datos.Lector["Apellido"];
                    nombreCompleto = $"{nombre} {apellido}";
                }
                return nombreCompleto;
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
