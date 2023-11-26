using System.Data;
using System.Data.SqlClient;
using Tarea3BDI.Models;

namespace Tarea3BDI.Data
{
    public class PlanillaMensualXEmpleadoDatos
    {
        public List<PlanillaMesXEmpleadoModel> Listar(string clientIPAddress, int idUsuario, int IdEmpleado)
        {
            var oLista = new List<PlanillaMesXEmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarPlanillaXMesEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@inPostIP", clientIPAddress);
                cmd.Parameters.AddWithValue("@inIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@inIdEmpleado", IdEmpleado);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PlanillaMesXEmpleadoModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            SalarioNeto = Convert.ToDecimal(dr["SalarioNeto"]),
                            SalarioBruto = Convert.ToDecimal(dr["SalarioBruto"]),
                            TotalDeducciones = Convert.ToDecimal(dr["TotalDeducciones"]),
                            IdMesPlanilla = Convert.ToInt32(dr["IdMesPlanilla"])

                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }

        public List<DeduccionesEmpleado> ObtenerDeduccionesPorEmpleado(int idUsuario, int IdEmpleado)
        {
            
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    using (var command = new SqlCommand("ObtenerDeduccionesPorEmpleado", conexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@inIdEmpleado", IdEmpleado));
                        command.Parameters.Add(new SqlParameter("@inIdUsuario", idUsuario));

                        using (var reader = command.ExecuteReader())
                        {
                            List<DeduccionesEmpleado> deducciones = new List<DeduccionesEmpleado>();

                            while (reader.Read())
                            {
                                DeduccionesEmpleado deduccion = new DeduccionesEmpleado
                                {
                                    NombreDeduccion = reader["NombreDeduccion"].ToString(),
                                    Porcentaje = Convert.ToDecimal(reader["Porcentaje"]),
                                    MontoDeduccion = Convert.ToDecimal(reader["MontoDeduccion"])
                                };

                                deducciones.Add(deduccion);
                            }

                            return deducciones;
                        }
                    }
                }
        }

    }
}
