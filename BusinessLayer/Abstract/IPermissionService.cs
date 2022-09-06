using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPermissionService
    {
        void AddPermission(Permission Permission);
        void DeletePermission(Permission Permission);
        void UpdatePermission(Permission Permission);
        List<Permission> GetListPermission();
        Permission GetPermissionById(int id);
    }
}
