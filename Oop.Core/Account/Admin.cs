using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Infrastructure;

namespace Oop.Core.Account
{
    public class Admin : BaseAccount
    {
        public Admin()
        {
            AddRole(Constant.Role.Admin);
        }
    }
}
