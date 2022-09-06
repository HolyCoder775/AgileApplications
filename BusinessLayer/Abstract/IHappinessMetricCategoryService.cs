using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHappinessMetricCategoryService
    {
        void AddHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory);
        void DeleteHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory);
        void UpdateHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory);
        List<HappinessMetricCategory> GetListHappinessMetricCategory();
        HappinessMetricCategory GetHappinessMetricCategoryById(int id);
    }
}
