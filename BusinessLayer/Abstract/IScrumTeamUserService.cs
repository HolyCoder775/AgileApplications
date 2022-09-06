using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IScrumTeamUserService
    {
        void AddScrumTeamUser(ScrumTeamUser scrumTeamUser);
        void DeleteScrumTeamUser(ScrumTeamUser scrumTeamUser);
        void UpdateScrumTeamUser(ScrumTeamUser scrumTeamUser);
        List<ScrumTeamUser> GetListScrumTeamUser();
        ScrumTeamUser GetRoleById(int id);
        List<ScrumTeamUser> GetListScrumTeamUserWithUser();
        List<ScrumTeamUser> GetListScrumTeamUsersWithScrumTeam();
    }
}
