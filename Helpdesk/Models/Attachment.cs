using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpdesk.Models
{
    public class Attachment : BaseEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}