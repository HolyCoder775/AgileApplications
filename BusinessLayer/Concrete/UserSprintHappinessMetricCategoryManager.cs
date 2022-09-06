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
    public class UserSprintHappinessMetricCategoryManager : IUserSprintHappinessMetricCategoryService
    {
        IUserSprintHappinessMetricCategoryDal _userSprintHappinessMetricCategoryDal;
        public UserSprintHappinessMetricCategoryManager(IUserSprintHappinessMetricCategoryDal userSprintHappinessMetricCategoryDal)
        {
            _userSprintHappinessMetricCategoryDal = userSprintHappinessMetricCategoryDal;
        }
        public void AddUserSprintHappinessMetricCategory(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory)
        {
            _userSprintHappinessMetricCategoryDal.Insert(userSprintHappinessMetricCategory);
        }

        public void DeleteUserSprintHappinessMetricCategory(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory)
        {
            _userSprintHappinessMetricCategoryDal.Delete(userSprintHappinessMetricCategory);
        }

        public List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategory()
        {
            return _userSprintHappinessMetricCategoryDal.GetListAll();
        }

        public List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategoryWithHappinessMetricCategory()
        {
            return _userSprintHappinessMetricCategoryDal.GetListWithHappinessMetricCategory();
        }

        public List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategoryWithSprint()
        {
            return _userSprintHappinessMetricCategoryDal.GetListWithSprint();
        }

        public List<UserSprintHappinessMetricCategory> GetListUserSprintHappinessMetricCategoryWithUser()
        {
            return _userSprintHappinessMetricCategoryDal.GetListWithUser();
        }

        public UserSprintHappinessMetricCategory GetUserSprintHappinessMetricCategoryById(int id)
        {
            return _userSprintHappinessMetricCategoryDal.GetById(id);
        }

        public void UpdateUserSprintHappinessMetricCategory(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory)
        {
            _userSprintHappinessMetricCategoryDal.Update(userSprintHappinessMetricCategory);
        }
    }
}
