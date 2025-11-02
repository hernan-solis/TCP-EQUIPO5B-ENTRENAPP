using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;

namespace Business
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {

            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Teléfono, Edad, Objetivos, Rol, Género, FechaFinSuscripción, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorID from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    /*
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Objetivos = (string)datos.Lector["Objetivos"];
                    aux.Rol = (string)datos.Lector["Rol"];
                    aux.Genero = (string)datos.Lector["Género"];
                    aux.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
                    aux.DiasDisponibles = (string)datos.Lector["DíaDisponibles"];
                    aux.Lesiones = (string)datos.Lector["Lesiones"];
                    aux.CondicionMedica = (string)datos.Lector["CondiciónMédica"];
                    aux.Comentarios = (string)datos.Lector["Comentarios"];
                    aux.ProfesorId = (int)datos.Lector["ProfesorID"];
                  

                    lista.Add(aux);
                      */
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

        public Usuario ObtenerUsuarioPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = null;

            try
            {
                datos.setearConsulta("SELECT ID, Nombre, Apellido, Email, Contraseña, Teléfono, Edad, Objetivos, Rol, Género, FechaFinSuscripción, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorID FROM Usuarios WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    /*
                    usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["ID"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Contrasenia = (string)datos.Lector["Contraseña"];
                    usuario.Telefono = (string)datos.Lector["Teléfono"];
                    usuario.Edad = (int)datos.Lector["Edad"];
                    usuario.Objetivos = (string)datos.Lector["Objetivos"];
                    usuario.Rol = (string)datos.Lector["Rol"];
                    usuario.Genero = (string)datos.Lector["Género"];
                    usuario.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
                    usuario.DiasDisponibles = (string)datos.Lector["DíasDisponibles"];
                    usuario.Lesiones = (string)datos.Lector["Lesiones"];
                    usuario.CondicionMedica = (string)datos.Lector["CondiciónMédica"];
                    usuario.Comentarios = (string)datos.Lector["Comentarios"];
                    usuario.ProfesorId = (int)datos.Lector["ProfesorID"];
                    */
                }

                return usuario;
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


        public int Loguear(string email, string contrasenia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID FROM Usuarios WHERE Email = @email AND Contraseña = @contrasenia AND FechaFinSuscripción >= @fechaActual");
                datos.setearParametro("@email", email);
                datos.setearParametro("@contrasenia", contrasenia);
                datos.setearParametro("@fechaActual", DateTime.Now);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    // Devuelve el ID del usuario
                    return (int)datos.Lector["ID"];
                }

                // Si no se encontró el usuario, devuelve 0
                return 0;
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
