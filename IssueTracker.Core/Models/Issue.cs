using IssueTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Models
{
    public class Issue
    {
        public long Id { get; set; }

        public string Descripton { get; set; }

        public PriorityEnum Priority { get; set; }

        public long DepartmentId { get; set; }

        public IssueStatusEnum Status { get; set; }

        public Guid? ResolverId { get; set; }

        public Guid ReporterId { get; set; }

        public string Comment { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatorId { get; set; }

        public Guid ModifiedById { get; set; }

        public DateTime Modified { get; set; }

        public virtual User Creator { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual Department Department { get; set; }

        public virtual User Resolver { get; set; }

        public virtual User Reporter { get; set; }
    }
}
