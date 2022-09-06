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
    public class ScrumTeamUserController : Controller
    {
        ScrumTeamUserManager scrumTeamUserManager = new ScrumTeamUserManager(new EFScrumTeamUserRepository());
        public IActionResult Index()
        {
            var scrumTeamUserWithUser = scrumTeamUserManager.GetListScrumTeamUserWithUser();
            var scrumTeamUserWithScrumTeam = scrumTeamUserManager.GetListScrumTeamUsersWithScrumTeam();
            return View(scrumTeamUserWithUser);
        }

        [HttpGet]
        public IActionResult AddScrumTeamUser()
        {
            ScrumTeamManager scrumTeamManager = new ScrumTeamManager(new EFScrumTeamRepository());
            UserManager userManager = new UserManager(new EFUserRepository());

            List<SelectListItem> scrumTeamValues = (from x in scrumTeamManager.GetListScrumTeam()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ScrumTeamId.ToString()
                                                    }
                                                    ).ToList();
            List<SelectListItem> userValues = (from x in userManager.GetListUser()
                                               select new SelectListItem
                                               {
                                                   Text = x.FullName,
                                                   Value = x.UserId.ToString()
                                               }
                                               ).ToList();
            ViewBag.scrumTeamValues = scrumTeamValues;
            ViewBag.userValues = userValues;
            return View();
        }

        [HttpPost] 
        public IActionResult AddScrumTeamUser(ScrumTeamUser scrumTeamUser)
        {
            scrumTeamUser.IsActive = true;
            scrumTeamUser.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            scrumTeamUser.ModifiedBy = scrumTeamUser.CreatedBy;
            scrumTeamUser.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            scrumTeamUserManager.AddScrumTeamUser(scrumTeamUser);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteScrumTeamUser(int id)
        {
            var scrumTeamUserValue = scrumTeamUserManager.GetRoleById(id);
            scrumTeamUserValue.IsActive = false;
            scrumTeamUserManager.UpdateScrumTeamUser(scrumTeamUserValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditScrumTeamUser(int id)
        {
            var scrumTeamUserValues = scrumTeamUserManager.GetRoleById(id);

            ScrumTeamManager scrumTeamManager = new ScrumTeamManager(new EFScrumTeamRepository());
            UserManager userManager = new UserManager(new EFUserRepository());

            List<SelectListItem> scrumTeamValues = (from x in scrumTeamManager.GetListScrumTeam()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ScrumTeamId.ToString()
                                                    }
                                                    ).ToList();
            List<SelectListItem> userValues = (from x in userManager.GetListUser()
                                               select new SelectListItem
                                               {
                                                   Text = x.FullName,
                                                   Value = x.UserId.ToString()
                                               }
                                               ).ToList();
            ViewBag.scrumTeamValues = scrumTeamValues;
            ViewBag.userValues = userValues;
            return View(scrumTeamUserValues);
        }

        [HttpPost]
        public IActionResult EditScrumTeamUser(ScrumTeamUser scrumTeamUser)
        {
            scrumTeamUser.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            scrumTeamUser.IsActive = true;
            scrumTeamUserManager.UpdateScrumTeamUser(scrumTeamUser);
            return RedirectToAction("Index");
        }
    }
}
