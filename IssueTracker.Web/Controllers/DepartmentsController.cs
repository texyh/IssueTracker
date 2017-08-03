using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Core.Interfaces;
using IssueTracker.Core.Models;

namespace IssueTracker.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentComposerService _departmentService;

        public DepartmentsController(IDepartmentComposerService service)
        {
            _departmentService = service;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetDepartments();
            return View(departments);
        }

        public async Task<IActionResult> Department(long id = 0)
        {
            var department = await _departmentService.GetDepartmentAsync(id);
            return View(department);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Department(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            await _departmentService.SaveDepartment(department);

            return RedirectToAction("Index");
        }
    }
}