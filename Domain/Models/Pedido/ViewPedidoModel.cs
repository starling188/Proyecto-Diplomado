﻿

using Domain.Entities;
using Domain.Models.DetallePedido;

namespace Domain.Models.Pedido
{
    public class ViewPedidoModel
    {
        public int IdPedido { get; set; }
        public string NombreCliente { get; set; }
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public ICollection<ViewDetallePedidoModel> DetallePedido { get; set; } = new List<ViewDetallePedidoModel>();    
    }
}
