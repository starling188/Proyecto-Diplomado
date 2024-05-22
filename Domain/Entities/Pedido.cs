﻿using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public int IdCliente { get; set; }
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public Mesa Mesa { get; set; }
    }
}
