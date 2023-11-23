using System.Data.SqlTypes;

namespace Tarea3BDI.Models
{
    public class EmpleadoModel
    {
        

        public int Id { get; set; }

        public string NombreEmpleado { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public string NombreTipoDocumento { get; set; }

        public int IdTipoDocumento { get; set; }

        public string ValorTipoDocumento { get; set; }

        public string NombreDepartamento { get; set; }

        public int IdDepartamento { get; set; }
        
        public string NombrePuesto { get; set; }
        public int IdPuesto { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public bool EsActivo { get; set; }

        public int IdUsuario { get; set; }

        public int IdEmpleado { get; set; }

    }
}
