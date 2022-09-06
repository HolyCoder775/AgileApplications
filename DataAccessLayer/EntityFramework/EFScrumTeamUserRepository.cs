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
    public class EFScrumTeamUserRepository : GenericRepository<ScrumTeamUser>, IScrumTeamUserDal
    {
        Context c = new Context(); 
        public List<ScrumTeamUser> GetListWithScrumTeam()
        {
            return c.ScrumTeamUsers.Include(x => x.ScrumTeam).ToList();
        }

        public List<ScrumTeamUser> GetListWithUser()
        {
            return c.ScrumTeamUsers.Include(x => x.User).ToList();
        }

    }
}
