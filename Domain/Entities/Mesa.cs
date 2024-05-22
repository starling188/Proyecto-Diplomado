using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mesa : BaseEntity
    {
        public int Capacidad { get; set; }
        public string? Estado { get; set; } 
    }
}
