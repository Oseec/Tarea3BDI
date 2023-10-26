using System.Data.SqlTypes;

namespace Tarea3BDI.Models
{
    public class EmpleadoModel
    {

        public int Id { get; set; }

        public string NombreEmpleado { get; set; }

        public DateOnly FechaDeNacimiento { get; set; }

        public int IdTipoDocumento { get; set; }

        public string ValorTipoDocumento { get; set; }

        public int IdDepartamento { get; set; }
        
        public int IdPuesto { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public SqlBoolean EsActivo { get; set; }

    }
}
