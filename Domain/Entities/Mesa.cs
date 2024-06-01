using Domain.Core;


namespace Domain.Entities
{
    public class Mesa : BaseEntity
    {
        public int Capacidad { get; set; }
        public string? Estado { get; set; } 
    }
}
