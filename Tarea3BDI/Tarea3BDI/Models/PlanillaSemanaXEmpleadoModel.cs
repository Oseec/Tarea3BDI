using System.Data.SqlTypes;

namespace Tarea3BDI.Models
{
    public class PlanillaSemanaXEmpleadoModel
    {
        public int Id { get; set; }

        public int IdEmpleado { get; set; }

        public SqlMoney SalarioNeto { get; set; }

        public SqlMoney SalarioBruto { get; set; }

        public SqlMoney TotalDeducciones { get; set; }

        public int HorasOrdinarias { get; set; }

        public int HorasExtraNormales { get; set; }

        public int HorasExtraDobles { get; set; }


    }
}
