using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        IRolePermissionDal _rolePermissionDal;
        public RolePermissionManager(IRolePermissionDal rolePermissionDal)
        {
            _rolePermissionDal = rolePermissionDal;
        }
        public void AddRolePermission(RolePermission rolePermission)
        {
            _rolePermissionDal.Insert(rolePermission);
        }

        public void DeleteRolePermission(RolePermission rolePermission)
        {
            _rolePermissionDal.Delete(rolePermission);
        }

        public List<RolePermission> GetListRolePermission()
        {
            return _rolePermissionDal.GetListAll();
        }

        public List<RolePermission> GetListRolePermissionWithPermission()
        {
            return _rolePermissionDal.GetListWithPermission();
        }

        public List<RolePermission> GetListRolePermissionWithRole()
        {
            return _rolePermissionDal.GetListWithRole();
        }

        public RolePermission GetRolePermissionById(int id)
        {
            return _rolePermissionDal.GetById(id);
        }



        public void UpdateRolePermission(RolePermission rolePermission)
        {
            _rolePermissionDal.Update(rolePermission);
        }
    }
}
