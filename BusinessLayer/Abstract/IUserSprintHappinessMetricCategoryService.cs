using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserSprintHappinessMetricCategoryService
    {
        void AddUserSprintHappinessMetricCategory(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory);
        void DeleteUserSprintHappinessMetricCategory(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory);
        void UpdateUserSprintHappinessMetricCategory(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory);
        List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategory();
        UserSprintHappinessMetricCategory GetUserSprintHappinessMetricCategoryById(int id);
        List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategoryWithUser();
        List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategoryWithSprint();
        List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategoryWithHappinessMetricCategory();
    }
}
