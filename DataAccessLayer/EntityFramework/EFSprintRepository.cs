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
    public class EFSprintRepository : GenericRepository<Sprint>, ISprintDal
    {
        Context c = new Context();
        public List<Sprint> GetListWithScrumTeam()
        {
            return c.Sprints.Include(x => x.ScrumTeam).ToList();
        }
    }
}
