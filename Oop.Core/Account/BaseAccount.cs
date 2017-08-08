using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Core.Events;

namespace Oop.Core.Account
{
    public abstract class BaseAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Role.Role> Roles { get; set; }

        public virtual bool IsHasRole(string roleName)
        {
            return Roles.FirstOrDefault(x => x.Name == roleName) != null;
        }

        public virtual void AddRole(string roleName)
        {
            if (Roles == null)
                Roles = new List<Role.Role>();
            Roles.Add(new Role.Role {Name = roleName});
        }

        public virtual void RemoveRole(string roleName)
        {
            var role = Roles.FirstOrDefault(x => x.Name == roleName);
            if (role != null)
                Roles.Remove(role);
        }

        public bool IsValidPassword(string password)
        {
            // @todo encoded password
            var encodedPassword = password;
            return Password == encodedPassword;
        }

        public void UpdatePassword(string newPassword)
        {
            // @todo encoded password
            var encodedPassword = newPassword;
            Password = encodedPassword;
            OnChangePassword?.Invoke(this);
        }

        public event AccountChangePassword OnChangePassword;
    }
}
