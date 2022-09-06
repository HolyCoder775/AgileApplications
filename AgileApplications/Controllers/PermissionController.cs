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
    public class PermissionController : Controller
    {
        PermissionManager permissionManager = new PermissionManager(new EFPermissionRepository());
        public IActionResult Index()
        {
            var values = permissionManager.GetListPermission();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPermission()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPermission(Permission permission)
        {
            PermissionValidator permissionValidor = new PermissionValidator();
            ValidationResult result = permissionValidor.Validate(permission);
            
            if(result.IsValid)
            {
                permission.IsActive = true;
                permission.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                permission.ModifiedBy = permission.CreatedBy;
                permission.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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

        public IActionResult DeletePermission(int id)
        {
            var permissionvalue = permissionManager.GetPermissionById(id);
            permissionvalue.IsActive = false;
            permissionManager.UpdatePermission(permissionvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPermission(int id)
        {
            var permissionValues = permissionManager.GetPermissionById(id);
            return View(permissionValues);
        }

        [HttpPost]
        public IActionResult EditPermission(Permission permission)
        {
            permission.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            permission.IsActive = true;
            permissionManager.UpdatePermission(permission);
            return RedirectToAction("Index");
        }
    }
}
