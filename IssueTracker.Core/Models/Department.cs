using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Models
{
    public class Department
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Guid AdminId { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatorId { get; set; }

        public Guid ModifiedById { get; set; }

        public DateTime Modified { get; set; }

        public virtual User Creator { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual User Admin { get; set; }
    }
}
