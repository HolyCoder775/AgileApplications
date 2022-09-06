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
    public class RoleController : Controller
    {
        RoleManager roleManager = new RoleManager(new EFRoleRepository());
        public IActionResult Index()
        {
            var values = roleManager.GetListRole();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            RoleValidator roleValidator = new RoleValidator();
            ValidationResult result = roleValidator.Validate(role);
            if(result.IsValid)
            {
                role.IsActive = true;
                role.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                role.ModifiedBy = role.CreatedBy;
                role.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                roleManager.AddRole(role);
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

        public IActionResult DeleteRole(int id)
        {
            var roleValue = roleManager.GetRoleById(id);
            roleValue.IsActive = false;
            roleManager.UpdateRole(roleValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var roleValue = roleManager.GetRoleById(id);
            return View(roleValue);
        }

        [HttpPost] 
        public IActionResult EditRole(Role role)
        {
            role.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            role.IsActive = true;
            roleManager.UpdateRole(role);
            return RedirectToAction("Index");
        }
    }
}
