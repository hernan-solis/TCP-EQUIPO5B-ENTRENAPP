using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AlumnoNegocio
    {
        public List<Alumno> Listar()
        {

            List<Alumno> lista = new List<Alumno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Status, Teléfono, Edad, Objetivos, Género, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorId from Usuarios where Rol = 'Alumno'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Alumno aux = new Alumno();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Rol = (string)datos.Lector["Rol"];
                    aux.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
                    aux.Status = (bool)datos.Lector["Status"];
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Objetivo = (string)datos.Lector["Objetivos"];
                    aux.Genero = (string)datos.Lector["Género"];
                    aux.DiasDisponibles = (string)datos.Lector["DíasDisponibles"];
                    aux.Lesiones = (string)datos.Lector["Lesiones"];
                    aux.CondicionMedica = (string)datos.Lector["CondiciónMédica"];
                    aux.Comentarios = (string)datos.Lector["Comentarios"];

                    ProfesorNegocio profesorNegocio = new ProfesorNegocio();

                    aux.Profesor = profesorNegocio.ObtenerNombreCompletoPorId((int)datos.Lector["ProfesorId"]);



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
        public Alumno ObtenerPorId (int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Status, Teléfono, Edad, Objetivos, Género, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorId from Usuarios where ID = @id");
                datos.setearParametro("@id",id);
                datos.ejecutarLectura();

                Alumno aux = new Alumno();


                if (datos.Lector.Read())
                {

                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Rol = (string)datos.Lector["Rol"];
                    aux.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
                    aux.Status = (bool)datos.Lector["Status"];
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Objetivo = (string)datos.Lector["Objetivos"];
                    aux.Genero = (string)datos.Lector["Género"];
                    aux.DiasDisponibles = (string)datos.Lector["DíasDisponibles"];
                    aux.Lesiones = (string)datos.Lector["Lesiones"];
                    aux.CondicionMedica = (string)datos.Lector["CondiciónMédica"];
                    aux.Comentarios = (string)datos.Lector["Comentarios"];

                    ProfesorNegocio profesorNegocio = new ProfesorNegocio();

                    aux.Profesor = profesorNegocio.ObtenerNombreCompletoPorId((int)datos.Lector["ProfesorId"]);



                   

                }

                return aux;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Alumno> ListarPorProfesor(int profesorId)

    
        {
            List<Alumno> lista = new List<Alumno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Status, Teléfono, Edad, Objetivos, Género, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorId from Usuarios where Rol = 'Alumno' and ProfesorID = @idBuscado");
                datos.setearParametro("@idBuscado", profesorId);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Alumno aux = new Alumno();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Rol = (string)datos.Lector["Rol"];
                    aux.FechaFinSuscripcion = (DateTime)datos.Lector["FechaFinSuscripción"];
                    aux.Status = (bool)datos.Lector["Status"];
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Objetivo = (string)datos.Lector["Objetivos"];
                    aux.Genero = (string)datos.Lector["Género"];
                    aux.DiasDisponibles = (string)datos.Lector["DíasDisponibles"];
                    aux.Lesiones = (string)datos.Lector["Lesiones"];
                    aux.CondicionMedica = (string)datos.Lector["CondiciónMédica"];
                    aux.Comentarios = (string)datos.Lector["Comentarios"];

                    ProfesorNegocio profesorNegocio = new ProfesorNegocio();

                    aux.Profesor = profesorNegocio.ObtenerNombreCompletoPorId((int)datos.Lector["ProfesorId"]);



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


        // OBLIGATORIO ASIGNAR UN PROFESOR AL CREAR UN ALUMNO
        public void Agregar(Alumno nuevo, int profesorId)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                INSERT INTO Usuarios 
                     (Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Teléfono, Edad, Objetivos, Género, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorId)
                    VALUES 
                     (@Nombre, @Apellido, @Email, @Contraseña, 'Alumno', @FechaFinSuscripción, @Teléfono, @Edad, @Objetivos, @Género, @DíasDisponibles, @Lesiones, @CondiciónMédica, @Comentarios, @ProfesorId)
                    ");

                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Contraseña", nuevo.Contrasenia);
                datos.setearParametro("@FechaFinSuscripción", nuevo.FechaFinSuscripcion);
                datos.setearParametro("@Teléfono", nuevo.Telefono);
                datos.setearParametro("@Edad", nuevo.Edad);
                datos.setearParametro("@Objetivos", nuevo.Objetivo);
                datos.setearParametro("@Género", nuevo.Genero);
                datos.setearParametro("@DíasDisponibles", nuevo.DiasDisponibles);
                datos.setearParametro("@Lesiones", nuevo.Lesiones);
                datos.setearParametro("@CondiciónMédica", nuevo.CondicionMedica);
                datos.setearParametro("@Comentarios", nuevo.Comentarios);
                datos.setearParametro("@ProfesorId", profesorId);

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

        public void Modificar(Alumno alumno)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            UPDATE Usuarios SET 
                Nombre = @Nombre,
                Apellido = @Apellido,
                Email = @Email,
                Contraseña = @Contraseña,
                FechaFinSuscripción = @FechaFinSuscripción,
                Status = @Status,
                Teléfono = @Teléfono,
                Edad = @Edad,
                Objetivos = @Objetivos,
                Género = @Género,
                DíasDisponibles = @DíasDisponibles,
                Lesiones = @Lesiones,
                CondiciónMédica = @CondiciónMédica,
                Comentarios = @Comentarios
            WHERE ID = @ID AND Rol = 'Alumno'
            ");

                datos.setearParametro("@ID", alumno.Id);
                datos.setearParametro("@Nombre", alumno.Nombre);
                datos.setearParametro("@Apellido", alumno.Apellido);
                datos.setearParametro("@Email", alumno.Email);
                datos.setearParametro("@Contraseña", alumno.Contrasenia);
                datos.setearParametro("@FechaFinSuscripción", alumno.FechaFinSuscripcion);
                datos.setearParametro("@Status", alumno.Status);
                datos.setearParametro("@Teléfono", alumno.Telefono);
                datos.setearParametro("@Edad", alumno.Edad);
                datos.setearParametro("@Objetivos", alumno.Objetivo);
                datos.setearParametro("@Género", alumno.Genero);
                datos.setearParametro("@DíasDisponibles", alumno.DiasDisponibles);
                datos.setearParametro("@Lesiones", alumno.Lesiones);
                datos.setearParametro("@CondiciónMédica", alumno.CondicionMedica);
                datos.setearParametro("@Comentarios", alumno.Comentarios);

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

        //Sirve para actualizar el profesor asignado a un alumno
        public void ModificarProfesorAsignado(Alumno alumno, int idProfesor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                UPDATE Usuarios 
                 SET ProfesorId = @ProfesorId
                 WHERE ID = @ID AND Rol = 'Alumno'
                 ");

                datos.setearParametro("@ProfesorId", idProfesor);
                datos.setearParametro("@ID", alumno.Id);

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

        //Eliminacion Logia

        public void EliminarLogico(int id)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarioNegocio.EliminarLogico(id);
        }
    }
}
