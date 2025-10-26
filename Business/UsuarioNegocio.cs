using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;

namespace Business
{
    internal class UsuarioNegocio
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
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Contraseña = (string)datos.Lector["Contraseña"];
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
