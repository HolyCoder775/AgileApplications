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
    public class ScrumTeamManager : IScrumTeamService
    {
        IScrumTeamDal _scrumTeamDal;
        public ScrumTeamManager(IScrumTeamDal scrumTeamDal)
        {
            _scrumTeamDal = scrumTeamDal;

        }
        public void AddScrumTeam(ScrumTeam scrumTeam)
        {
            _scrumTeamDal.Insert(scrumTeam);
        }

        public void DeleteScrumTeam(ScrumTeam scrumTeam)
        {
            _scrumTeamDal.Delete(scrumTeam);
        }

        public List<ScrumTeam> GetListScrumTeam()
        {
            return _scrumTeamDal.GetListAll();
        }

        public ScrumTeam GetScrumTeamById(int id)
        {
            return _scrumTeamDal.GetById(id);
        }

        public void UpdateScrumTeam(ScrumTeam scrumTeam)
        {
            _scrumTeamDal.Update(scrumTeam);
        }
    }
}
