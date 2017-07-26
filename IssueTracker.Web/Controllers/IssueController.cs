using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Core.Interfaces;
using IssueTracker.Core.Models;

namespace IssueTracker.Web.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueComposerService _issueService;

        public IssueController(IIssueComposerService service)
        {
            _issueService = service;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var issues = await _issueService.GetOpenIssues();
            return View(issues);
        }

        [HttpGet]
        public async Task<ActionResult> Issue(long id = 0)
        {
            var issue = await _issueService.GetIssue(id);
            return View(issue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Issue(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return View(issue);
            }

            await _issueService.SaveIssue(issue);
            return RedirectToAction("Index");
        }

        
    }
}