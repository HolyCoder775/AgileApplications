using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRolePermissionService
    {
        void AddRolePermission(RolePermission rolePermission);
        void DeleteRolePermission(RolePermission rolePermission);
        void UpdateRolePermission(RolePermission rolePermission);
        List<RolePermission> GetListRolePermission();
        RolePermission GetRolePermissionById(int id);
        List<RolePermission> GetListRolePermissionWithRole();
        List<RolePermission> GetListRolePermissionWithPermission();
    }
}
