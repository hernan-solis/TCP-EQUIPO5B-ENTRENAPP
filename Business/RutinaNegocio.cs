using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    aux.Dia = diaNegocio.ListarPorRutinaId((int)datos.Lector["ID"]);

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
        

     public Rutina ObtenerRutinaPorId(int rutinaId)
        {
   
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, UsuarioID, ProfesorID, Título, Descripción from Rutinas WHERE ID = @rutinaId");
                datos.setearParametro("@rutinaId", rutinaId);
                datos.ejecutarLectura();
                AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                ProfesorNegocio profesorNegocio = new ProfesorNegocio();
                DiaNegocio diaNegocio = new DiaNegocio();
                Rutina aux = new Rutina();

                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Alumno = alumnoNegocio.ObtenerPorId((int)datos.Lector["UsuarioID"]);
                    aux.Profesor = profesorNegocio.ObtenerProfesorPorId((int)datos.Lector["ProfesorID"]);
                    aux.Titulo = (string)datos.Lector["Título"];
                    aux.Descripcion = (string)datos.Lector["Descripción"];
                    aux.Dia = diaNegocio.ListarPorRutinaId((int)datos.Lector["ID"]);
                }

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

        public Rutina ObtenerRutinaPorIdAlumno(int idAlumno)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, UsuarioID, ProfesorID, Título, Descripción from Rutinas WHERE UsuarioID = @idAlumno");
                datos.setearParametro("@idAlumno", idAlumno);
                datos.ejecutarLectura();
                AlumnoNegocio alumnoNegocio = new AlumnoNegocio();
                ProfesorNegocio profesorNegocio = new ProfesorNegocio();
                DiaNegocio diaNegocio = new DiaNegocio();
                Rutina aux = new Rutina();

                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Alumno = alumnoNegocio.ObtenerPorId((int)datos.Lector["UsuarioID"]);
                    aux.Profesor = profesorNegocio.ObtenerProfesorPorId((int)datos.Lector["ProfesorID"]);
                    aux.Titulo = (string)datos.Lector["Título"];
                    aux.Descripcion = (string)datos.Lector["Descripción"];
                    aux.Dia = diaNegocio.ListarPorRutinaId((int)datos.Lector["ID"]);
                }

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

        public void Agregar(Rutina rutina)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Rutinas (UsuarioID, ProfesorID, Título, Descripción) VALUES (@usuarioId, @profesorId, @titulo, @descripcion)");
                datos.setearParametro("@usuarioId", rutina.Alumno.Id);
                datos.setearParametro("@profesorId", rutina.Profesor.Id);
                datos.setearParametro("@titulo", rutina.Titulo);
                datos.setearParametro("@descrpcion", rutina.Descripcion);

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

        public void Modificar (Rutina rutina)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Rutinas SET UsuarioID = @usuarioId, ProfesorID = @profesorId, Título = @titulo, Descripción = @descripcion WHERE ID = @id;");
                datos.setearParametro("@usuarioId", rutina.Alumno.Id);
                datos.setearParametro("@profesorId", rutina.Profesor.Id);
                datos.setearParametro("@titulo", rutina.Titulo);
                datos.setearParametro("@descrpcion", rutina.Descripcion);

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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //falta la eliminacion de ejercicio asignado

                datos.setearConsulta("DELETE FROM Día WHERE RutinaID = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();

                datos.setearConsulta("DELETE FROM Rutinas WHERE id = @id");
                datos.setearParametro("@id", id);
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
