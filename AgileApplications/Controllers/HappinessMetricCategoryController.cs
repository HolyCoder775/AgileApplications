using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgileApplications.Controllers
{
    public class HappinessMetricCategoryController : Controller
    {
        HappinessMetricCategoryManager happinessMetricCategoryManager = new HappinessMetricCategoryManager(new EFHappinessMetricCategoryRepository());
        public IActionResult Index()
        {
            var values = happinessMetricCategoryManager.GetListHappinessMetricCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHappinessMetricCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHappinessMetricCategory(HappinessMetricCategory happinessMetricCategory)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(happinessMetricCategory);
            if(result.IsValid)
            {
                happinessMetricCategory.IsActive = true;
                happinessMetricCategory.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                happinessMetricCategory.ModifiedBy = happinessMetricCategory.CreatedBy;
                happinessMetricCategory.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                happinessMetricCategoryManager.AddHappinessMetricCategory(happinessMetricCategory);
                return RedirectToAction("Index");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = happinessMetricCategoryManager.GetHappinessMetricCategoryById(id);
            category.IsActive = false;
            happinessMetricCategoryManager.UpdateHappinessMetricCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var categoryValues = happinessMetricCategoryManager.GetHappinessMetricCategoryById(id);
            return View(categoryValues);
        }

        [HttpPost]
        public IActionResult EditCategory(HappinessMetricCategory happinessMetricCategory)
        {
            happinessMetricCategory.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            happinessMetricCategory.IsActive = true;
            happinessMetricCategoryManager.UpdateHappinessMetricCategory(happinessMetricCategory);
            return RedirectToAction("Index");
        }
    }
}
