using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISprintService
    {
        void AddSprint(Sprint sprint);
        void DeleteSprint(Sprint sprint);
        void UpdateSprint(Sprint sprint);
        List<Sprint> GetListSprint();
        Sprint GetSprintById(int id);
        List<Sprint> GetListSprintWithScrumTeam();
    }
}
