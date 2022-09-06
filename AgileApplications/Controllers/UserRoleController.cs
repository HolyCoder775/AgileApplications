using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileApplications.Controllers
{
    public class UserRoleController : Controller
    {
        UserRoleManager userRoleManager = new UserRoleManager(new EFUserRoleRepository());
        public IActionResult Index()
        {
            var userRoleWithUser = userRoleManager.GetListUserRoleListWithUser();
            var userRoleWithRole = userRoleManager.GetListUserRoleWithRole();
            return View(userRoleWithUser);
        }

        [HttpGet]
        public IActionResult AddUserRole()
        {
            UserManager userManager = new UserManager(new EFUserRepository());
            RoleManager roleManager = new RoleManager(new EFRoleRepository());

            List<SelectListItem> userValues = (from x in userManager.GetListUser()
                                               select new SelectListItem
                                               {
                                                   Text = x.FullName,
                                                   Value = x.UserId.ToString()
                                               }
                                               ).ToList();

            List<SelectListItem> roleValues = (from x in roleManager.GetListRole()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.RoleId.ToString()
                                               }
                                               ).ToList();
            ViewBag.userValues = userValues;
            ViewBag.roleValues = roleValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddUserRole(UserRole userRole)
        {
            UserRoleValidator userRoleValidator = new UserRoleValidator();
            ValidationResult result = userRoleValidator.Validate(userRole);

            if(result.IsValid)
            {
                userRole.IsActive = true;
                userRole.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                userRole.ModifiedBy = userRole.CreatedBy;
                userRole.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                userRoleManager.AddUserRole(userRole);
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

        public IActionResult DeleteUserRole(int id)
        {
            var userValue = userRoleManager.GetUserroleById(id);
            userValue.IsActive = false;
            userRoleManager.UpdateUser(userValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUserRole(int id)
        {
            var userRoleValues = userRoleManager.GetUserroleById(id);
            UserManager userManager = new UserManager(new EFUserRepository());
            RoleManager roleManager = new RoleManager(new EFRoleRepository());

            List<SelectListItem> userValues = (from x in userManager.GetListUser()
                                               select new SelectListItem
                                               {
                                                   Text = x.FullName,
                                                   Value = x.UserId.ToString()
                                               }
                                               ).ToList();

            List<SelectListItem> roleValues = (from x in roleManager.GetListRole()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.RoleId.ToString()
                                               }
                                               ).ToList();
            ViewBag.userValues = userValues;
            ViewBag.roleValues = roleValues;
            return View(userRoleValues);
        }

        [HttpPost] 
        public IActionResult EditUserRole(UserRole userRole)
        {
            userRole.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            userRole.IsActive = true;
            userRoleManager.UpdateUser(userRole);
            return RedirectToAction("Index");
        }
    }
}
