using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileApplications.Controllers
{
    public class UserSprintHappinessMetricCategoryController : Controller
    {
        UserSprintHappinessMetricCategoryManager userSprintHappinessMetricCategoryManager = new UserSprintHappinessMetricCategoryManager(new EFUserSprintHappinessMetricCategoryRepository());
        public IActionResult Index()
        {
            var listUserSprintHappinessMetricCategoryWithHappinessMetricCategory = userSprintHappinessMetricCategoryManager.GetListUserSprintHappinessMetricCategoryWithHappinessMetricCategory();
            var listUserSprintHappinessMetricCategoryWithUser = userSprintHappinessMetricCategoryManager.GetListUserSprintHappinessMetricCategoryWithUser();
            var listUserSprintHappinessMetricCategoryWithSprint = userSprintHappinessMetricCategoryManager.GetListUserSprintHappinessMetricCategoryWithSprint();
            return View(listUserSprintHappinessMetricCategoryWithHappinessMetricCategory);
        }

        [HttpGet]
        public IActionResult AddUSHMC() // USHMC = UserSprintHappinessMetricCategory
        {
            UserManager userManager = new UserManager(new EFUserRepository());
            SprintManager sprintManager = new SprintManager(new EFSprintRepository());
            HappinessMetricCategoryManager happinessMetricCategory = new HappinessMetricCategoryManager(new EFHappinessMetricCategoryRepository());

            List<SelectListItem> userValues = (from x in userManager.GetListUser()
                                               select new SelectListItem
                                               {
                                                   Text = x.FullName,
                                                   Value = x.UserId.ToString()
                                               }
                                               ).ToList();

            List<SelectListItem> sprintValues = (from x in sprintManager.GetListSprint()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.SprintId.ToString()
                                                 }
                                               ).ToList();

            List<SelectListItem> categoryValues = (from x in happinessMetricCategory.GetListHappinessMetricCategory()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.HappinessMetricCategoryId.ToString()
                                                   }
                                                   ).ToList();

            ViewBag.userValues = userValues;
            ViewBag.sprintValues = sprintValues;
            ViewBag.categoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddUSHMC(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory)
        {
            userSprintHappinessMetricCategory.IsActive = true;
            userSprintHappinessMetricCategory.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            userSprintHappinessMetricCategory.ModifiedBy = userSprintHappinessMetricCategory.CreatedBy;
            userSprintHappinessMetricCategory.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            userSprintHappinessMetricCategoryManager.AddUserSprintHappinessMetricCategory(userSprintHappinessMetricCategory);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUSHMC(int id)
        {
            var ushmcValue = userSprintHappinessMetricCategoryManager.GetUserSprintHappinessMetricCategoryById(id);
            ushmcValue.IsActive = false;
            userSprintHappinessMetricCategoryManager.UpdateUserSprintHappinessMetricCategory(ushmcValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUSHMC(int id)
        {
            var ushmcValues = userSprintHappinessMetricCategoryManager.GetUserSprintHappinessMetricCategoryById(id);
            UserManager userManager = new UserManager(new EFUserRepository());
            SprintManager sprintManager = new SprintManager(new EFSprintRepository());
            HappinessMetricCategoryManager happinessMetricCategory = new HappinessMetricCategoryManager(new EFHappinessMetricCategoryRepository());

            List<SelectListItem> userValues = (from x in userManager.GetListUser()
                                               select new SelectListItem
                                               {
                                                   Text = x.FullName,
                                                   Value = x.UserId.ToString()
                                               }
                                               ).ToList();

            List<SelectListItem> sprintValues = (from x in sprintManager.GetListSprint()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.SprintId.ToString()
                                                 }
                                               ).ToList();

            List<SelectListItem> categoryValues = (from x in happinessMetricCategory.GetListHappinessMetricCategory()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.HappinessMetricCategoryId.ToString()
                                                   }
                                                   ).ToList();

            ViewBag.userValues = userValues;
            ViewBag.sprintValues = sprintValues;
            ViewBag.categoryValues = categoryValues;
            return View(ushmcValues);
        }

        [HttpPost]
        public IActionResult EditUSHMC(UserSprintHappinessMetricCategory userSprintHappinessMetricCategory)
        {
            userSprintHappinessMetricCategory.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            userSprintHappinessMetricCategory.IsActive = true;
            userSprintHappinessMetricCategoryManager.UpdateUserSprintHappinessMetricCategory(userSprintHappinessMetricCategory);
            return RedirectToAction("Index");
        }
    }
}
