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
    public class EFUserSprintHappinessMetricCategoryRepository : GenericRepository<UserSprintHappinessMetricCategory>, IUserSprintHappinessMetricCategoryDal
    {
        Context c = new Context();
        public List<UserSprintHappinessMetricCategory> GetListWithHappinessMetricCategory()
        {
            return c.UserSprintHappinessMetricCategories.Include(x => x.HappinessMetricCategory).ToList();
        }

        public List<UserSprintHappinessMetricCategory> GetListWithSprint()
        {
            return c.UserSprintHappinessMetricCategories.Include(x => x.Sprint).ToList();
        }

        public List<UserSprintHappinessMetricCategory> GetListWithUser()
        {
            return c.UserSprintHappinessMetricCategories.Include(x => x.User).ToList();
        }
    }
}
