using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Data.Base
{
    public abstract class AuditTable
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedByOnUtc { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime ModifiedByOnUtc { get; set; }
    }
}
