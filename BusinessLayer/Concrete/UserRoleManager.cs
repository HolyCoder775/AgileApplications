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
    public class UserRoleManager : IUserRolesService
    {
        IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }
        public void AddUserRole(UserRole userRole)
        {
            _userRoleDal.Insert(userRole); ;
        }

        public void DeleteUser(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
        }

        public List<UserRole> GetListUserRole()
        {
            return _userRoleDal.GetListAll();
        }

        public List<UserRole> GetListUserRoleListWithUser()
        {
            return _userRoleDal.GetListWithUser();
        }

        public List<UserRole> GetListUserRoleWithRole()
        {
            return _userRoleDal.GetListWithRole();
        }

        public UserRole GetUserroleById(int id)
        {
            return _userRoleDal.GetById(id);
        }

        public void UpdateUser(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
        }
    }
}

