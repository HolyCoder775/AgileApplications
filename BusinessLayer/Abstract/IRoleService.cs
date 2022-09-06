using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRoleService
    {
        void AddRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetListRole();
        Role GetRoleById(int id);
    }
}
