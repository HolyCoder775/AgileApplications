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
    public class SprintController : Controller
    {
        SprintManager sprintManager = new SprintManager(new EFSprintRepository());
        public IActionResult Index()
        {
            var sprintWithScrumTeam = sprintManager.GetListSprintWithScrumTeam();
            return View(sprintWithScrumTeam);
        }

        [HttpGet]
        public IActionResult AddSprint()
        {
            ScrumTeamManager scrumTeamManager = new ScrumTeamManager(new EFScrumTeamRepository());

            List<SelectListItem> scrumTeamValues = (from x in scrumTeamManager.GetListScrumTeam()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ScrumTeamId.ToString()
                                                    }
                                                 ).ToList();

            ViewBag.scrumTeamValues = scrumTeamValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddSprint(Sprint sprint)
        {
            SprintValidator sprintValidator = new SprintValidator();
            ValidationResult result = sprintValidator.Validate(sprint);
            sprint.IsActive = true;
            if (result.IsValid)
            {
                sprint.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                sprint.ModifiedBy = sprint.CreatedBy;
                sprint.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                sprintManager.AddSprint(sprint);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }

        public IActionResult DeleteSprint(int id)
        {
            var sprintValue = sprintManager.GetSprintById(id);
            sprintValue.IsActive = false;
            sprintManager.UpdateSprint(sprintValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSprint(int id)
        {
            var sprintValue = sprintManager.GetSprintById(id);
            ScrumTeamManager scrumTeamManager = new ScrumTeamManager(new EFScrumTeamRepository());

            List<SelectListItem> scrumTeamValues = (from x in scrumTeamManager.GetListScrumTeam()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ScrumTeamId.ToString()
                                                    }
                                                 ).ToList();

            ViewBag.scrumTeamValues = scrumTeamValues;
            return View(sprintValue);
        }
        [HttpPost]
        public IActionResult EditSprint(Sprint sprint)
        {
            sprint.ModifiedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            sprint.IsActive = true;
            sprintManager.UpdateSprint(sprint);
            return RedirectToAction("Index");
        }
    }
}
