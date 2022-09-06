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
    public class SprintManager : ISprintService
    {
        ISprintDal _sprintDal;
        public SprintManager(ISprintDal sprintDal)
        {
            _sprintDal = sprintDal;
        }
        public void AddSprint(Sprint sprint)
        {
            _sprintDal.Insert(sprint);
        }

        public void DeleteSprint(Sprint sprint)
        {
            _sprintDal.Delete(sprint);
        }

        public List<Sprint> GetListSprint()
        {
            return _sprintDal.GetListAll();
        }

        public List<Sprint> GetListSprintWithScrumTeam()
        {
            return _sprintDal.GetListWithScrumTeam();
        }

        public Sprint GetSprintById(int id)
        {
            return _sprintDal.GetById(id);
        }

        public void UpdateSprint(Sprint sprint)
        {
            _sprintDal.Update(sprint);
        }
    }
}
