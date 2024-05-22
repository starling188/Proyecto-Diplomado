using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallePedido : BaseEntity
    {
        public int IdPedido { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public Pedido Pedido { get; set; }
        public Menu Menu { get; set; }
    }
}
