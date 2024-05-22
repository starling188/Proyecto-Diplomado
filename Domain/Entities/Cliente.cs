using Domain.Core;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        
    }
}
