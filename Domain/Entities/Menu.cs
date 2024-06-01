using Domain.Core;


namespace Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Categoria { get; set; }
    }
}
