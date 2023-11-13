using Tarea3BDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Tarea3BDI.Data
{
    public class DatosEmpleado
    {
                
        public List<EmpleadoModel> Listar(string clientIPAddress, int idUsuario)
        {
            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarEmpleadosConDetalles", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                cmd.Parameters.AddWithValue("@inIdUsuario", idUsuario);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            
                            NombreEmpleado = dr["NombreEmpleado"].ToString(),
                            FechaDeNacimiento = Convert.ToDateTime(dr["FechaDeNacimiento"]),
                            IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]),
                            NombreTipoDocumento = dr["NombreTipoDocumento"].ToString(),
                            ValorTipoDocumento = dr["ValorTipoDocumento"].ToString(),
                            NombreDepartamento = dr["NombreDepartamento"].ToString(),
                            IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                            NombrePuesto = dr["NombrePuesto"].ToString(),
                            IdPuesto = Convert.ToInt32(dr["IdPuesto"]),
                            Usuario = dr["Usuario"].ToString(),
                            EsActivo = Convert.ToBoolean((dr["EsActivo"])),

                        });
                    }
                }
            }
            return oLista;
        }

        public List<EmpleadoModel> ListarPorNombre(string NombreEmpleado, string clientIPAddress, int idUsuario)
        {
            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarEmpleadoConDetallesPorNombre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inNombreEmpleado", NombreEmpleado);
                cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                cmd.Parameters.AddWithValue("@inIdUsuario", idUsuario);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {

                            NombreEmpleado = dr["NombreEmpleado"].ToString(),
                            FechaDeNacimiento = Convert.ToDateTime(dr["FechaDeNacimiento"]),
                            IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]),
                            NombreTipoDocumento = dr["NombreTipoDocumento"].ToString(),
                            ValorTipoDocumento = dr["ValorTipoDocumento"].ToString(),
                            NombreDepartamento = dr["NombreDepartamento"].ToString(),
                            IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                            NombrePuesto = dr["NombrePuesto"].ToString(),
                            IdPuesto = Convert.ToInt32(dr["IdPuesto"]),
                            Usuario = dr["Usuario"].ToString(),
                            EsActivo = Convert.ToBoolean((dr["EsActivo"])),

                        });
                    }
                }
            }
            return oLista;
        }

        public bool InsertarEmpleado(EmpleadoModel empleadoModel, string clientIPAddress, int IdUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("@inNombreEmpleado", empleadoModel.NombreEmpleado);
                    cmd.Parameters.AddWithValue("@inFechaDeNacimiento", empleadoModel.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("@inIdTipoDocumento", empleadoModel.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@inValorTipoDocumento", empleadoModel.ValorTipoDocumento);
                    cmd.Parameters.AddWithValue("@inIdDepartamento", empleadoModel.IdDepartamento);
                    cmd.Parameters.AddWithValue("@inIdPuesto", empleadoModel.IdPuesto);
                    cmd.Parameters.AddWithValue("@inUsuario", empleadoModel.Usuario);
                    cmd.Parameters.AddWithValue("@inPassword", empleadoModel.Password);
                    cmd.Parameters.AddWithValue("@inEsActivo", empleadoModel.EsActivo);
                    cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                    cmd.Parameters.AddWithValue("@inIdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta=false;
            }

            return rpta;
        }

        public bool Eliminar(string NombreEmpleado, string postIP, int idUsuario)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    using (var command = new SqlCommand("EliminarEsActivo", conexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@inNombreEmpleado", NombreEmpleado));
                        command.Parameters.Add(new SqlParameter("@inPostIP", postIP));
                        command.Parameters.Add(new SqlParameter("@inIdUsuario", idUsuario));

                        int rowsAffected = command.ExecuteNonQuery();

                        // Si rowsAffected es mayor a cero, significa que la operación fue exitosa
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                // Manejar la excepción si es necesario
                return (false); // Indicar que hubo un error
            }
        }

        public bool Editar(EmpleadoModel empleadoModel, string clientIPAddress, int IdUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditarEmpleado", conexion);
                    cmd.Parameters.AddWithValue("@inNombreEmpleado", empleadoModel.NombreEmpleado);
                    cmd.Parameters.AddWithValue("@inFechaDeNacimiento", empleadoModel.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("@inNombreTipoDocumento", empleadoModel.NombreTipoDocumento);
                    cmd.Parameters.AddWithValue("@inValorTipoDocumento", empleadoModel.ValorTipoDocumento);
                    cmd.Parameters.AddWithValue("@inNombreDepartamento", empleadoModel.NombreDepartamento);
                    cmd.Parameters.AddWithValue("@inNombrePuesto", empleadoModel.NombrePuesto);
                    cmd.Parameters.AddWithValue("@inUsuario", empleadoModel.Usuario);
                    cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                    cmd.Parameters.AddWithValue("@inIdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }




    }
}
