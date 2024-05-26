using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Domain.Common
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; }
        DateTime CreatedAt { get; set; }
        public string CreatedBy{ get; set; }
        DateTime LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
