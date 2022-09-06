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
    public class HappinessMetricCategoryManager : IHappinessMetricCategoryService
    {
        IHappinessMetricCategoryDal _happinessMetricCategoryDal;
        public HappinessMetricCategoryManager(IHappinessMetricCategoryDal happinessMetricCategoryDal)
        {
            _happinessMetricCategoryDal = happinessMetricCategoryDal;
        }
        public void AddHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory)
        {
            _happinessMetricCategoryDal.Insert(happinessMetricCategory);
        }

        public void DeleteHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory)
        {
            _happinessMetricCategoryDal.Delete(happinessMetricCategory);
        }

        public HappinessMetricCategory GetHappinessMetricCategoryById(int id)
        {
            return _happinessMetricCategoryDal.GetById(id);
        }

        public List<HappinessMetricCategory> GetListHappinessMetricCategory()
        {
            return _happinessMetricCategoryDal.GetListAll();
        }

        public void UpdateHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory)
        {
            _happinessMetricCategoryDal.Update(happinessMetricCategory);
        }
    }
}
