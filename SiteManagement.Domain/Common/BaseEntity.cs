using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain
{
    public abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
    }
}
