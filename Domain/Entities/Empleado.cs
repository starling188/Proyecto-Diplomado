using Domain.Core;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
    }
}
