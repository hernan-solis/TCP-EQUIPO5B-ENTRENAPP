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
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, Status, Teléfono, Edad from Usuarios where Rol = 'Profesor'");
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
                    aux.Status = (bool)datos.Lector["Status"];

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
                datos.setearConsulta("SELECT ID, Nombre, Apellido, Email, Contraseña, Rol, Status, Teléfono, Edad FROM Usuarios WHERE ID = @idBuscado");
                datos.setearParametro("@idBuscado", id);
                datos.ejecutarLectura();

                datos.Lector.Read(); // necesario para posicionarse en la primera fila

                aux.Id = (int)datos.Lector["ID"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Apellido = (string)datos.Lector["Apellido"];
                aux.Email = (string)datos.Lector["Email"];
                aux.Contrasenia = (string)datos.Lector["Contraseña"];
                aux.Rol = (string)datos.Lector["Rol"];
                aux.Status = (bool)datos.Lector["Status"];
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

        public void Agregar(Profesor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                INSERT INTO Usuarios 
                     (Nombre, Apellido, Email, Contraseña, Rol, Teléfono, Edad, Status)
                    VALUES 
                     (@Nombre, @Apellido, @Email, @Contraseña, @Rol, @Teléfono, @Edad, @Status) ");

                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Contraseña", nuevo.Contrasenia);
                datos.setearParametro("@Rol", nuevo.Rol);
                datos.setearParametro("@Teléfono", nuevo.Telefono);
                datos.setearParametro("@Edad", nuevo.Edad);
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
                  Status = @Status
                 WHERE ID = @ID AND Rol = 'Profesor'");

                datos.setearParametro("@Nombre", profesor.Nombre);
                datos.setearParametro("@Apellido", profesor.Apellido);
                datos.setearParametro("@Email", profesor.Email);
                datos.setearParametro("@Contrasenia", profesor.Contrasenia);
                datos.setearParametro("@Telefono", profesor.Telefono);
                datos.setearParametro("@Edad", profesor.Edad);
                datos.setearParametro("@Status", profesor.Status);
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

        // ELIMINACION LOGICA

        public void EliminarLogico(int id)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarioNegocio.EliminarLogico(id);
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

        public int ObtenerProfesorConMenosAlumnos()
        {
            List<Profesor> listaProfesores = Listar();

            //validacion para saber si hay profesores en la lista
            if (listaProfesores == null || listaProfesores.Count == 0)
            {
                return -1;
            }

            Profesor profesorMenorAlumno = listaProfesores

             // Ordena por el número de alumnos (de menor a mayor)
            .OrderBy(prof => prof.Alumnos.Count)
            //Captura el primero de la lista
            .FirstOrDefault();

            // Devuelve el ID del profesor encontrado
            if (profesorMenorAlumno != null)
            {
                return profesorMenorAlumno.Id;
            }

            return -1;
        }

    }
}
