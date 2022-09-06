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
    public class ScrumTeamUserManager : IScrumTeamUserService
    {
        IScrumTeamUserDal _scrumTeamUserDal;
        public ScrumTeamUserManager(IScrumTeamUserDal scrumTeamUserDal)
        {
            _scrumTeamUserDal = scrumTeamUserDal;
        }
        public void AddScrumTeamUser(ScrumTeamUser scrumTeamUser)
        {
            _scrumTeamUserDal.Insert(scrumTeamUser);
        }

        public void DeleteScrumTeamUser(ScrumTeamUser scrumTeamUser)
        {
            _scrumTeamUserDal.Delete(scrumTeamUser);
        }

        public List<ScrumTeamUser> GetListScrumTeamUser()
        {
            return _scrumTeamUserDal.GetListAll();
        }

        public List<ScrumTeamUser> GetListScrumTeamUsersWithScrumTeam()
        {
            return _scrumTeamUserDal.GetListWithScrumTeam();
        }

        public List<ScrumTeamUser> GetListScrumTeamUserWithUser()
        {
            return _scrumTeamUserDal.GetListWithUser();
        }

        public ScrumTeamUser GetRoleById(int id)
        {
            return _scrumTeamUserDal.GetById(id);
        }

        public void UpdateScrumTeamUser(ScrumTeamUser scrumTeamUser)
        {
            _scrumTeamUserDal.Update(scrumTeamUser);
        }
    }
}
