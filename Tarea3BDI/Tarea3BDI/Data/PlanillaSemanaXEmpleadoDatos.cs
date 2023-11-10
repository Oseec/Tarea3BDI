using System.Data;
using System.Data.SqlClient;
using Tarea3BDI.Models;

namespace Tarea3BDI.Data
{
    public class PlanillaSemanalXEmpleadoDatos
    {
        public List<PlanillaSemanaXEmpleadoModel> Listar(string clientIPAddress, int idUsuario)
        {
            var oLista = new List<PlanillaSemanaXEmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarPlanillaXSemanaEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                cmd.Parameters.AddWithValue("@inIdUsuario", idUsuario);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PlanillaSemanaXEmpleadoModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            SalarioNeto = Convert.ToDecimal(dr["SalarioNeto"]),
                            SalarioBruto = Convert.ToDecimal(dr["SalarioBruto"]),
                            TotalDeducciones = Convert.ToDecimal(dr["TotalDeducciones"]),
                            HorasOrdinarias = Convert.ToInt32(dr["HorasOrdinarias"]),
                            HorasExtraNormales = Convert.ToInt32(dr["HorasExtraNormales"]),
                            HorasExtraDobles = Convert.ToInt32(dr["HorasExtraDobles"])
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }
    }
}
