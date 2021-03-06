﻿using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using System.Threading.Tasks;
using IssueTracker.Core.Enums;
using IssueTracker.Core.ViewModels;

namespace IssueTracker.Service
{
    public class IssueComposerService : IIssueComposerService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserContext _userContext;
        private readonly IIssueMailer _issueMailer;

        public IssueComposerService(
            IIssueRepository repository,
            IUserContext userContext,
            IIssueMailer issueMailer,
            IDepartmentRepository departmentRepository
            )
        {
            _issueRepository = repository;
            _userContext = userContext;
            _departmentRepository = departmentRepository;
            _issueMailer = issueMailer;
        }

        public async Task<IEnumerable<Issue>> AssignedIssues(Guid? userId)
        {
            if(!userId.HasValue)
            {
                userId = _userContext.GetUserId();
            }

            return await _issueRepository.AssignedIssues(userId.Value);
        }

        public async Task<IEnumerable<Issue>> CurentUserIssues()
        {
            var userId = _userContext.GetUserId();

            return await _issueRepository.CurrentUserIssues(userId);

        }

        public async Task<IEnumerable<Issue>> GetClosedIssues()
        {
            return await _issueRepository.GetClosedIssues(); 
        }

        public async Task<SaveIssueViewModel> GetIssue(long issueId)
        {
            var departments = await _departmentRepository.GetDepartments();
            var issue = new SaveIssueViewModel()
            {
                Departments = departments
            };
            if (issueId == default(long))
            {
                issue.ToViewModel(new Issue());
                return issue;
            }

            var dbIssue = await _issueRepository.GetIssue(issueId);
            issue.ToViewModel(dbIssue);

            return issue;
        }

        public async Task<IEnumerable<Issue>> GetOpenIssues()
        {
            return await _issueRepository.GetOpenIssues();
        }

        public async Task<Issue> SaveIssue(Issue issue)
        {
            var userId = _userContext.GetUserId();
            issue.ModifiedById = userId;
            issue.Modified = DateTime.UtcNow;

            if (issue.Id ==  default(long))
            {
                issue.Status = IssueStatusEnum.Open;
                issue.Created = DateTime.UtcNow;
                issue.CreatorId = userId;
                await _issueMailer.EmailNewIssue(issue.DepartmentId);
                return await _issueRepository.SaveIssue(issue);
            }

            var dbIssue = await _issueRepository.GetIssue(issue.Id);
            dbIssue.Priority = issue.Priority;
            dbIssue.Comment = issue.Comment;
            dbIssue.Status = issue.Status;
            dbIssue.DepartmentId = issue.DepartmentId;
            dbIssue.Description = issue.Description;
            dbIssue.ResolverId = issue.ResolverId;

            await _issueRepository.UpdateIssue(dbIssue);
            return dbIssue;
        }
    }
}
