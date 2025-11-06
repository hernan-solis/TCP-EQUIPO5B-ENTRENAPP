using Models;
using System;
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
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Contraseña, Rol, FechaFinSuscripción, Teléfono, Edad, Objetivos, DíasDisponibles, Lesiones, CondiciónMédica, Comentarios, ProfesorId from Usuarios");
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
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Objetivo = (string)datos.Lector["Objetivos"];
                    aux.DiasDisponibles = (string)datos.Lector["DíasDisponibles"];
                    aux.Lesiones = (string)datos.Lector["Lesiones"];
                    aux.CondicionMedica = (string)datos.Lector["CondiciónMédica"];
                    aux.Comentarios = (string)datos.Lector["Comentarios"];

                    //ProfesorId se puede agregar la lógica para obtener el profesor si es necesario



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
