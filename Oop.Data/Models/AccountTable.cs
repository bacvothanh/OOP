using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Data.Base;

namespace Oop.Data.Models
{
    public class AccountTable : AuditTable
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<RoleTable> Roles { get; set; }
    }
}
