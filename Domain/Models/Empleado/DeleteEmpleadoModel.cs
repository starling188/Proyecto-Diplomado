

using System.Text.Json.Serialization;

namespace Domain.Models.Empleado
{
    public class DeleteEmpleadoModel
    {
        [JsonIgnore]
        public int IdEmpleado { get; set; }
    }
}
