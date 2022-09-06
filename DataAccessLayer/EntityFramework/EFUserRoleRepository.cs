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
    public class EFUserRoleRepository : GenericRepository<UserRole>, IUserRoleDal
    {
        Context c = new Context();
        public List<UserRole> GetListWithRole()
        {
            return c.UserRoles.Include(x => x.Role).ToList();
        }

        public List<UserRole> GetListWithUser()
        {
            return c.UserRoles.Include(x => x.User).ToList();
        }
    }
}
