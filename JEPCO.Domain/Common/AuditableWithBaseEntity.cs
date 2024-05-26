using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Domain.Common
{
    public class AuditableWithBaseEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
