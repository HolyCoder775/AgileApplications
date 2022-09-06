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
    public class ScrumTeamController : Controller
    {
        ScrumTeamManager scrumTeamManager = new ScrumTeamManager(new EFScrumTeamRepository());
        public IActionResult Index()
        {
            var values = scrumTeamManager.GetListScrumTeam();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddScrumTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddScrumTeam(ScrumTeam scrumTeam)
        {
            ScrumTeamValidator scrumTeamValidator = new ScrumTeamValidator();
            ValidationResult result = scrumTeamValidator.Validate(scrumTeam);
            if(result.IsValid)
            {
                scrumTeam.IsActive = true;
                scrumTeam.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                scrumTeam.ModifiedBy = scrumTeam.CreatedBy;
                scrumTeam.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                scrumTeamManager.AddScrumTeam(scrumTeam);
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

        public IActionResult DeleteScrumTeam(int id)
        {
            var scrumTeamValue = scrumTeamManager.GetScrumTeamById(id);
            scrumTeamValue.IsActive = false;
            scrumTeamManager.UpdateScrumTeam(scrumTeamValue);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditScrumTeam(int id)
        {
            var scrumTeamValues = scrumTeamManager.GetScrumTeamById(id);
            return View(scrumTeamValues);
        }

        [HttpPost]
        public IActionResult EditScrumTeam(ScrumTeam scrumTeam)
        {
            scrumTeam.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            scrumTeam.IsActive = true;
            scrumTeamManager.UpdateScrumTeam(scrumTeam);
            return RedirectToAction("Index");
        }

    }
}
