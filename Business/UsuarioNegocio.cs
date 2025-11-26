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
        public List<Usuario> Listar()
        {

            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, Status from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Rol = (string)datos.Lector["Rol"];           
                    aux.Status = (bool)datos.Lector["Status"];
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

        public Usuario ObtenerUsuarioPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = null;

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, Status from Usuarios WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    
                    usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["ID"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Contrasenia = (string)datos.Lector["Contraseña"];
                    usuario.Rol = (string)datos.Lector["Rol"];
                    usuario.Status = (bool)datos.Lector["Status"];

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

        public void Agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Usuarios (Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Status) VALUES (@Nombre, @Apellido, @Email, @Contraseña, @Rol,@Status)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Contraseña", nuevo.Contrasenia);
                datos.setearParametro("@Rol", nuevo.Rol);
                datos.setearParametro("@Status", nuevo.Status);
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

        public void Modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Contraseña = @Contraseña, Rol = @Rol, Status = @Status WHERE ID = @ID");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Contraseña", usuario.Contrasenia);
                datos.setearParametro("@Rol", usuario.Rol);
                datos.setearParametro("@ID", usuario.Id);
                datos.setearParametro("@Status", usuario.Status);
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

        //ELIMINACION FISICA, CUIDADO
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("Delete FROM Usuarios WHERE ID = @ID");
                datos.setearParametro("@ID", id);
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



        //ELIMINACION LOGICA

        public void EliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Status = @Status FROM Usuarios WHERE ID = @ID");
                datos.setearParametro("@ID", id);
                datos.setearParametro("@Status", 0);
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


        // SI COINCIDEN EMAIL Y CONTRASEÑA, DEVUELVE EL ID DEL USUARIO, SINO DEVUELVE 0
        // lUIEGO LA FECHA DE FIN DE SUSCRIPCIÓN LA VALIDAS EN EL LA LOGICA DEL PROGRAMA, NO ACA  
        public int Loguear(string email, string contrasenia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID FROM Usuarios WHERE (Email = @email AND Contraseña = @contrasenia AND Rol = 'Alumno') OR (Email = @email AND Contraseña = @contrasenia AND Rol = 'Gestor') OR (Email = @email AND Contraseña = @contrasenia AND Rol = 'Profesor')");
                datos.setearParametro("@email", email);
                datos.setearParametro("@contrasenia", contrasenia);

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
