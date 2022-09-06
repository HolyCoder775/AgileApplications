using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IScrumTeamService
    {
        void AddScrumTeam(ScrumTeam scrumTeam);
        void DeleteScrumTeam(ScrumTeam scrumTeam);
        void UpdateScrumTeam(ScrumTeam scrumTeam);
        List<ScrumTeam> GetListScrumTeam();
        ScrumTeam GetScrumTeamById(int id);
    }
}
