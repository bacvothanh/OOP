using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Core.Account
{
    public class Admin : BaseAccount
    {
        public Admin()
        {
            AddRole("admin");
        }
    }
}
