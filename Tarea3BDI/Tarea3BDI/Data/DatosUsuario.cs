using Tarea3BDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Tarea3BDI.Data
{
    public class DatosUsuario
    {

        public bool ValidacionLogin(string Username, string Pwd, int Tipo, string postIP)
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
                        command.Parameters.Add(new SqlParameter("@inUsername", Username));
                        command.Parameters.Add(new SqlParameter("@inPwd", Pwd));
                        command.Parameters.Add(new SqlParameter("@inTipo", Tipo));
                        command.Parameters.Add(new SqlParameter("@inPostIP", postIP));

                        // Parámetro de salida
                        var resultado = new SqlParameter("@UsuarioEncontrado", SqlDbType.Bit);
                        resultado.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultado);

                        command.ExecuteNonQuery();

                        return (bool)resultado.Value;
                    }
                }
            }
            catch (Exception e)
            {
                // Manejar la excepción si es necesario
                return false; // Indicar que hubo un error
            }
        }
    }
}

