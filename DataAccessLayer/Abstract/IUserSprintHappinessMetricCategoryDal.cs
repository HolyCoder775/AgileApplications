using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserSprintHappinessMetricCategoryDal : IGenericDal<UserSprintHappinessMetricCategory>
    {
        List<UserSprintHappinessMetricCategory> GetListWithUser();
        List<UserSprintHappinessMetricCategory> GetListWithSprint();
        List<UserSprintHappinessMetricCategory> GetListWithHappinessMetricCategory();
    }
}
