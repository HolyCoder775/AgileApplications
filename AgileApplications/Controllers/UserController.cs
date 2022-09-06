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
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EFUserRepository());

        public IActionResult Index()
        {
            var values = userManager.GetListUser();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(user);
            if(result.IsValid)
            {
                user.IsActive = true;
                user.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                user.ModifiedBy = user.CreatedBy;
                user.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                userManager.AddUser(user);
                return RedirectToAction("AddUser");
            } else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
            
        }

        public IActionResult DeleteUser(int id)
        {
            var userValue = userManager.GetUserById(id);
            userValue.IsActive = false;
            userManager.UpdateUser(userValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var userValue = userManager.GetUserById(id);

            return View(userValue);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            user.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            user.IsActive = true;
            userManager.UpdateUser(user);
            return RedirectToAction("Index");
        }
    }
}
