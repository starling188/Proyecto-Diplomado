﻿using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
