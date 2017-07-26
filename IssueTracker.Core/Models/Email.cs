using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Core.Models
{
    public class Email
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Sender { get; set; }

        public string[] Recipients { get; set; }

        public string[] Bcc { get; set; }

        public string[] CC { get; set; }
    }
}
