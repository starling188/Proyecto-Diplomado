



namespace Domain.Models.Pedido
{
    public class SavePedidoModel
    {
        public int IdDelCliente { get; set; }
        public int IdDeLaMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
      

    }
}
