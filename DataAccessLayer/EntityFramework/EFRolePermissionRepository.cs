using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFRolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionDal
    {
        Context c = new Context();

        public List<RolePermission> GetListWithPermission()
        {
            return c.RolePermissions.Include(x => x.Permission).ToList();
        }

        public List<RolePermission> GetListWithRole()
        {
            return c.RolePermissions.Include(x => x.Role).ToList();
        }
    }
}
