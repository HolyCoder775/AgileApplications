using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserRolesService
    {
        void AddUserRole(UserRole userRole);
        void DeleteUser(UserRole userRole);
        void UpdateUser(UserRole userRole);
        List<UserRole> GetListUserRole();
        UserRole GetUserroleById(int id);
        List<UserRole> GetListUserRoleListWithUser();
        List<UserRole> GetListUserRoleWithRole();
    }
}
