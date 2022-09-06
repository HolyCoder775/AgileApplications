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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public void AddRole(Role role)
        {
            _roleDal.Insert(role);
        }

        public void DeleteRole(Role role)
        {
            _roleDal.Delete(role);
        }

        public List<Role> GetListRole()
        {
            return _roleDal.GetListAll();
        }

        public Role GetRoleById(int id)
        {
            return _roleDal.GetById(id);
        }

        public void UpdateRole(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
