using Tarea3BDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Tarea3BDI.Data
{
    public class DatosUsuario
    {

        public bool ValidacionLogin(/*int Id,*/ string Pwd, int Tipo, string Username, string postIP)
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

        public int ObtieneIdUsuario(string Username, string Pwd, int Tipo)
        {
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                using (var command = new SqlCommand("ObtieneIdUsuario", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@inUsername", Username));
                    command.Parameters.Add(new SqlParameter("@inPwd", Pwd));
                    command.Parameters.Add(new SqlParameter("@inTipo", Tipo));

                    var idUsuarioParameter = new SqlParameter("@outIdUsuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idUsuarioParameter);

                    command.ExecuteNonQuery();

                    if (idUsuarioParameter.Value != DBNull.Value)
                    {
                        return (int)idUsuarioParameter.Value;
                    }
                    else
                    {
                        // El usuario no fue encontrado o la contraseña es incorrecta
                        return -1; // O un valor que indique que no se encontró el usuario
                    }

                }


            }
        }

    }
}

