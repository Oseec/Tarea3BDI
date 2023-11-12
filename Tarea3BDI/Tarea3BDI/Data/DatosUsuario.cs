using Tarea3BDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Tarea3BDI.Data
{
    public class DatosUsuario
    {

        public (bool, int) ValidacionLogin(/*int Id,*/ string Pwd, int Tipo, string Username, string postIP)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    using (var command = new SqlCommand("ValidacionLogin", conexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        //command.Parameters.Add(new SqlParameter("@inId", Id));
                        command.Parameters.Add(new SqlParameter("@inPwd", Pwd));
                        command.Parameters.Add(new SqlParameter("@inTipo", Tipo));
                        command.Parameters.Add(new SqlParameter("@inUsername", Username));
                        command.Parameters.Add(new SqlParameter("@inPostIP", postIP));

                        // Parámetro de salida
                        var resultado = new SqlParameter("@outResultado", SqlDbType.Bit);
                        resultado.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultado);

                        // Parámetro de salida para el IdUsuario
                        var idUsuario = new SqlParameter("@outIdUsuario", SqlDbType.Int);
                        idUsuario.Direction = ParameterDirection.Output;
                        command.Parameters.Add(idUsuario);

                        command.ExecuteNonQuery();

                        bool validacionResultado = (bool)resultado.Value;
                        int idUsuarioResultado = (idUsuario.Value != DBNull.Value) ? (int)idUsuario.Value : -1; // -1 si no se encontró un IdUsuario

                        return (validacionResultado, idUsuarioResultado);
                    }
                }
            }
            catch (Exception e)
            {  
                // Manejar la excepción si es necesario
                return (false, -1); // Indicar que hubo un error
            }
        }

        public int ValidarEmpleado(string Pwd, string Username, string postIP, int idUsuario)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    using (var command = new SqlCommand("ObtieneEmpleadoUsuarioPwd", conexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@inPostIP", postIP));
                        command.Parameters.Add(new SqlParameter("@inIdUsuario", idUsuario));
                        command.Parameters.Add(new SqlParameter("@inUsuario", Username));
                        command.Parameters.Add(new SqlParameter("@inPwd", Pwd));

                        // Parámetro de salida para el IdUsuario
                        var idEmpleado = new SqlParameter("@outIdEmpleado", SqlDbType.Int);
                        idEmpleado.Direction = ParameterDirection.Output;
                        command.Parameters.Add(idEmpleado);

                        command.ExecuteNonQuery();



                        int idEmpleadoResultado = (idEmpleado.Value != DBNull.Value) ? (int)idEmpleado.Value : -1; // -1 si no se encontró un IdUsuario

                        return idEmpleadoResultado;
                    }

                }
            }
            catch (Exception e)
            {
                // Manejar la excepción si es necesario
                return (-1); // Indicar que hubo un error
            }
        }

    }
}

