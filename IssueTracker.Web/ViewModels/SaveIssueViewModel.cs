//using IssueTracker.Core.Enums;
//using IssueTracker.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

//namespace IssueTracker.Core.ViewModels
//{
//    public class SaveIssueViewModel
//    {
       
//        public long Id { get; set; }

//        public string Description { get; set; }

//        public PriorityEnum Priority { get; set; }
        
//        public long DepartmentId { get; set; }

//        public IssueStatusEnum Status { get; set; }

//        public Guid? ResolverId { get; set; }

//        public Guid ReporterId { get; set; }

//        public string Comment { get; set; }
        
//        public IEnumerable<Department> Departments { get; set; }

//        public Issue ToIssue()
//        {
//            return new Issue
//            {
//                Id = Id,
//                Description = Description,
//                Priority = Priority,
//                DepartmentId = DepartmentId,
//                Status = Status,
//                ResolverId = ResolverId,
//                Comment = Comment
//            };
//        }

//        public void ToViewModel(Issue issue)
//        {
//            Id = issue.Id;
//            Description = issue.Description;
//            Priority = issue.Priority;
//            DepartmentId = issue.DepartmentId;
//            Status = issue.Status;
//            ResolverId = issue.ResolverId;
//            Comment = issue.Comment;
//        }
        
//    }
//}
