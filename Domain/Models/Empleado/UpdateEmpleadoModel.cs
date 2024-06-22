

using System.Text.Json.Serialization;

namespace Domain.Models.Empleado
{
    public class UpdateEmpleadoModel
    {
        [JsonIgnore]
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
    }
}
