using Tarea3BDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Tarea3BDI.Data
{
    public class DatosEmpleado
    {

        public List<EmpleadoModel> Listar(string clientIPAddress, int IdUsuario)
        {
            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarEmpleadosConDetalles", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                cmd.Parameters.AddWithValue("@inIdUsuario", IdUsuario);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            NombreEmpleado = dr["NombreEmpleado"].ToString(),
                            FechaDeNacimiento = Convert.ToDateTime(dr["FechaDeNacimiento"]),
                            IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]),
                            ValorTipoDocumento = dr["ValorTipoDocumento"].ToString(),
                            IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                            IdPuesto = Convert.ToInt32(dr["IdPuesto"]),
                            Usuario = dr["Usuario"].ToString(),
                            EsActivo = Convert.ToBoolean((dr["EsActivo"]))


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
                    cmd.Parameters.AddWithValue("Nombre", empleadoModel.NombreEmpleado);
                    cmd.Parameters.AddWithValue("Fecha de nacimiento", empleadoModel.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("Tipo de Documento", empleadoModel.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("Valor de documento", empleadoModel.ValorTipoDocumento);
                    cmd.Parameters.AddWithValue("Departamento", empleadoModel.IdDepartamento);
                    cmd.Parameters.AddWithValue("Puesto", empleadoModel.IdPuesto);
                    cmd.Parameters.AddWithValue("Usuario", empleadoModel.Usuario);
                    cmd.Parameters.AddWithValue("Contraseña", empleadoModel.Password);
                    cmd.Parameters.AddWithValue("EsActivo", empleadoModel.EsActivo);
                    cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                    cmd.Parameters.AddWithValue("@inIdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BeginExecuteNonQuery();
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

        


    }
}
