using System.Data.SqlTypes;

namespace Tarea3BDI.Models
{
    public class PlanillaMesXEmpleadoModel
    {
        public int Id { get; set; }

        public string NombreEmpleado { get; set; }

        public SqlMoney SalarioNeto { get; set; }

        public SqlMoney SalarioBruto { get; set; }

        public SqlMoney TotalDeducciones { get; set; }

        public int IdMesPlanilla { get; set; }


    }
}
