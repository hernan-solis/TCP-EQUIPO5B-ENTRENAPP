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
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Teléfono, Edad from Usuarios where Rol = 'Profesor'");
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
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Edad = (int)datos.Lector["Edad"];

                    AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                    aux.Alumnos = alumnoNegocio.ListarPorProfesor(aux.Id);

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

        public Profesor ObtenerProfesorPorId(int id)
        {
            Profesor aux = new Profesor();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Teléfono, Edad FROM Usuarios WHERE ID = @idBuscado");
                datos.setearParametro("@idBuscado", id);
                datos.ejecutarLectura();

                datos.Lector.Read(); // necesario para posicionarse en la primera fila

                aux.Id = (int)datos.Lector["ID"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Apellido = (string)datos.Lector["Apellido"];
                aux.Email = (string)datos.Lector["Email"];
                aux.Contrasenia = (string)datos.Lector["Contraseña"];
                aux.Rol = (string)datos.Lector["Rol"];
                aux.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
                aux.Telefono = (string)datos.Lector["Teléfono"];
                aux.Edad = (int)datos.Lector["Edad"];

                AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                aux.Alumnos = alumnoNegocio.ListarPorProfesor(aux.Id);

                return aux;
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

        public void Modificar(Profesor profesor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                 UPDATE Usuarios SET 
                  Nombre = @Nombre,
                  Apellido = @Apellido,
                   Email = @Email,
                   Contraseña = @Contrasenia,
                   Teléfono = @Telefono,
                    Edad = @Edad,
                  FechaFinSuscripción = @FechaFinSuscripcion
                 WHERE ID = @ID AND Rol = 'Profesor'");

                datos.setearParametro("@Nombre", profesor.Nombre);
                datos.setearParametro("@Apellido", profesor.Apellido);
                datos.setearParametro("@Email", profesor.Email);
                datos.setearParametro("@Contrasenia", profesor.Contrasenia);
                datos.setearParametro("@Telefono", profesor.Telefono);
                datos.setearParametro("@Edad", profesor.Edad);
                datos.setearParametro("@FechaFinSuscripcion", profesor.FechaFinSuscripcion);
                datos.setearParametro("@ID", profesor.Id);

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
