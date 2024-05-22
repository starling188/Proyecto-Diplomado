using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

        protected BaseEntity()
        {
            
            CreatedDate = DateTime.Now;
            IsActive = true;

        }

    }
}
