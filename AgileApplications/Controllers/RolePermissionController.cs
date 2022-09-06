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
    public class RolePermissionController : Controller
    {
        RolePermissionManager rolePermissionManager = new RolePermissionManager(new EFRolePermissionRepository());
        public IActionResult Index()
        {
            var rolePermissionsWithRoles = rolePermissionManager.GetListRolePermissionWithRole();
            var rolePermissionWithPermissions = rolePermissionManager.GetListRolePermissionWithPermission();
            return View(rolePermissionsWithRoles);
        }

        [HttpGet]
        public IActionResult AddRolePermission()
        {
            RoleManager roleManager = new RoleManager(new EFRoleRepository());
            PermissionManager permissionManager = new PermissionManager(new EFPermissionRepository());

            List<SelectListItem> roleValues = (from x in roleManager.GetListRole()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.RoleId.ToString()
                                               }
                                               ).ToList();
            List<SelectListItem> permissionValues = (from x in permissionManager.GetListPermission()
                                                          select new SelectListItem
                                                          {
                                                              Text = x.Name,
                                                              Value = x.PermissionId.ToString()
                                                          }
                                                          ).ToList();
            ViewBag.roleValues = roleValues;
            ViewBag.permissionValues = permissionValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddRolePermission(RolePermission rolePermission)
        {
            rolePermission.IsActive = true;
            rolePermission.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            rolePermission.ModifiedBy = rolePermission.CreatedBy;
            rolePermission.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            rolePermissionManager.AddRolePermission(rolePermission);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRolePermission(int id)
        {
            var rolePermissionValue = rolePermissionManager.GetRolePermissionById(id);
            rolePermissionValue.IsActive = false;
            rolePermissionManager.UpdateRolePermission(rolePermissionValue);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public IActionResult EditRolePermission(int id)
        {
            RoleManager roleManager = new RoleManager(new EFRoleRepository());
            PermissionManager permissionManager = new PermissionManager(new EFPermissionRepository());

            List<SelectListItem> roleValues = (from x in roleManager.GetListRole()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.RoleId.ToString()
                                               }
                                               ).ToList();
            List<SelectListItem> permissionValues = (from x in permissionManager.GetListPermission()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.PermissionId.ToString()
                                                     }
                                                          ).ToList();
            ViewBag.roleValues = roleValues;
            ViewBag.permissionValues = permissionValues;
            var rolePermissionValues = rolePermissionManager.GetRolePermissionById(id);
            return View(rolePermissionValues);
        }

        [HttpPost]
        public IActionResult EditRolePermission(RolePermission rolePermission)
        {
            rolePermission.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            rolePermission.IsActive = true;
            rolePermissionManager.UpdateRolePermission(rolePermission);
            return RedirectToAction("Index");
        }
    }
}
