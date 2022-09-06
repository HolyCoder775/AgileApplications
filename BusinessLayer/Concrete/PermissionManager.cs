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
    public class PermissionManager : IPermissionService
    {
        IPermissionDal _permissionDal;
        public PermissionManager(IPermissionDal permissionDal)
        {
            _permissionDal = permissionDal;
        }
        public void AddPermission(Permission permission)
        {
            _permissionDal.Insert(permission);
        }

        public void DeletePermission(Permission permission)
        {
            _permissionDal.Delete(permission);
        }

        public List<Permission> GetListPermission()
        {
            return _permissionDal.GetListAll();
        }

        public Permission GetPermissionById(int id)
        {
            return _permissionDal.GetById(id);
        }

        public void UpdatePermission(Permission permission)
        {
            _permissionDal.Update(permission);
        }
    }
}
