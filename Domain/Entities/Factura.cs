using Domain.Core;


namespace Domain.Entities
{
    public class Factura : BaseEntity
    {
        public int IdPedido { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public Pedido Pedido { get; set; }
    }
}
