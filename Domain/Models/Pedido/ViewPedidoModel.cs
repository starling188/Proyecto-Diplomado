



namespace Domain.Models.Pedido
{
    public class ViewPedidoModel
    {
        public int IdPedido { get; set; }
       
        public int IdDelCliente { get; set; }
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

    
    }
}
