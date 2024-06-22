


namespace Domain.Models.Pedido
{
    public class UpdatePedidoModel
    {
        public int IdCliente { get; set; }
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
       
    }
}
