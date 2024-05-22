using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
    }
}
