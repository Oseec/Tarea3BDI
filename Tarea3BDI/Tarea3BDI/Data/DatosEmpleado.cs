using Tarea3BDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace Tarea3BDI.Data
{
    public class DatosEmpleado
    {

        public List<EmpleadoModel> Listar()
        {
            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarEmpleadosConDetalle", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            NombreEmpleado = dr["NombreEmpleado"].ToString(),
                            FechaDeNacimiento = dr["FechaDeNacimiento"].GetType().ToString(),
                            IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]),
                            ValorTipoDocumento = dr["ValorTipoDocumento"].ToString(),
                            IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                            IdPuesto = Convert.ToInt32(dr["IdPuesto"]),
                            Usuario = dr["Usuario"].ToString(),
                            EsActivo = dr["EsActivo"].GetType().ToString()


                        });
                    }
                }
            }
            return oLista;
        }

    }
}
