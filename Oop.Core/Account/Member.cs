using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Core.Account
{
    public class Member : BaseAccount
    {
        public Member()
        {
            AddRole("member");
        }
    }
}
